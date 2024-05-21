using System;
using System.Collections;
using System.Data;

public class ClsFunciones
{
    #region Variables
    int i = 0;
    bool res = true;
    long CveEmpresa = 0;
    string LineBreak = "\n";
    string Msj = string.Empty;
    string SQL = string.Empty;
    DataTable dt = new DataTable();
    DataTable dtEmp = new DataTable();

    #endregion

    public string ObtieneMensajeExcepcion(Exception ex)
    {
        try
        {
            if (ex != null)
            {
                Msj = string.Format("Error {0}: {1}{2}", ex.HResult, ex.Message, LineBreak);

                if (ex.Data != null)
                {
                    Msj = string.Format("{0} Data:{1}", Msj, LineBreak);

                    foreach (DictionaryEntry param in ex.Data)
                    {
                        Msj = string.Format("{0} {1} = {2}{3}", Msj, param.Key, param.Value.ToString(), LineBreak);
                    }
                }
                if (ex.HelpLink != null)
                {
                    Msj = string.Format("{0} HelpLink: {1}{2}", Msj, ex.HelpLink, LineBreak);
                }
                if (ex.InnerException != null)
                {
                    Msj = string.Format("{0} InnerException: {1}{2}", Msj, ex.InnerException.Message, LineBreak);
                }
                if (ex.Source != null)
                {
                    Msj = string.Format("{0} Source: {1}{2}", Msj, ex.Source, LineBreak);
                }
                if (ex.StackTrace != null)
                {
                    Msj = string.Format("{0} StackTrace: {1}{2}", Msj, ex.StackTrace, LineBreak);
                }
                if (ex.TargetSite != null)
                {
                    Msj = string.Format("{0} TargetSite '{1}': {2}", Msj, ex.TargetSite.Name, LineBreak);

                    foreach (System.Reflection.ParameterInfo param in ex.TargetSite.GetParameters())
                    {
                        Msj = string.Format("{0} {1} = {2}{3}", Msj, param.Name, param.DefaultValue.ToString(), LineBreak);
                    }
                }
            }
            else
            {
                Msj = "Excepción no especificada.";
            }
        }
        catch (Exception exe)
        {
            Msj = Msj.Trim() + "\n" + exe.Message;
        }
        finally
        {
            Msj = Msj.Trim();
        }

        return Msj;
    }
    public string SQLescape(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return string.Empty;
        }
        else
        {
            return text.Replace("'", "''");
        }
    }
    public bool ClienteConSeguro(long NumCliente)
    {
        i = 0;
        res = false;
        CveEmpresa = 0;
        SQL = string.Empty;
        dt = new DataTable();
        dtEmp = new DataTable();

        try
        {
            SQL = " SELECT	 NVL(liga.cet_empclave,0)	cve_empresa\n ";
            SQL = SQL + " FROM	 eclient cte\n ";
            SQL = SQL + "		,eclient_empresa_trading liga\n ";
            SQL = SQL + "		,eempresas   emp\n ";
            SQL = SQL + " WHERE	 cte.cliclef	=	liga.cet_cliclef\n ";
            SQL = SQL + "	AND	emp.empclave	=	liga.cet_empclave \n ";
            SQL = SQL + "	AND	cte.cliclef		=	'" + NumCliente + "'\n ";
            SQL = SQL + " ORDER BY	1\n ";

            dtEmp = new BD().ObtieneDataTable(SQL);

            if (dtEmp != null)
            {
                if (dtEmp.Rows.Count > 0)
                {
                    for (i = 0; i < dtEmp.Rows.Count; i++)
                    {
                        try
                        {
                            if (dtEmp.Rows[0][0].ToString().Equals(string.Empty))
                            {
                                CveEmpresa = (long)Convert.ToDouble(dtEmp.Rows[0][0].ToString());

                                SQL = SQL + " SELECT	CCOCLAVE, CCO_CLICLEF, CCO_BPCCLAVE, CCO_YFOCLEF, CCO_DOUCLEF, CCO_CHOCLAVE, CCO_PARCLAVE \n ";
                                SQL = SQL + " FROM	ECLIENT_APLICA_CONCEPTOS \n ";
                                SQL = SQL + " WHERE	CCO_CLICLEF	=	'" + NumCliente + "' \n ";
                                SQL = SQL + " 	AND	CCO_CLICLEF	NOT IN (9954,9955,9956,9910,9929) \n ";
                                SQL = SQL + " 	AND	EXISTS	( \n ";
                                SQL = SQL + " 					SELECT	NULL \n ";
                                SQL = SQL + " 					FROM	EBASES_POR_CONCEPT \n ";
                                SQL = SQL + " 					WHERE	BPCCLAVE	=	CCO_BPCCLAVE \n ";
                                SQL = SQL + " 						AND	BPC_CHOCLAVE	IN	(	SELECT	CHOCLAVE \n ";
                                SQL = SQL + " 													FROM	ECONCEPTOSHOJA \n ";
                                SQL = SQL + " 													WHERE	CHOTIPOIE		=	'I' \n ";
                                SQL = SQL + " 														AND	CHONUMERO		=	183 /* CONCEPTO SEGURO DE MERCANCÍA  / NO SE CAMBIA */ \n ";
                                SQL = SQL + " 														AND	CHO_EMPCLAVE	=	'" + CveEmpresa + "' /* CAMBIAR CLAVE DE EMPRESA POR CLIENTE */ \n ";
                                SQL = SQL + " 												) \n ";
                                SQL = SQL + " 				) \n ";

                                dt = new BD().ObtieneDataTable(SQL);

                                if (dt != null)
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (!dt.Rows[0][0].ToString().Trim().Equals(string.Empty))
                                        {
                                            res = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            res = false;
                        }
                    }
                }
            }
        }
        catch
        {
            res = false;
        }
        finally
        {
            if (dt != null)
            {
                dt.Dispose();
                GC.SuppressFinalize(dt);
            }
            if (dtEmp != null)
            {
                dtEmp.Dispose();
                GC.SuppressFinalize(dtEmp);
            }
        }

        return res;
    }
    public bool Foraneo6(long Dieclave)
    {
        res = false;
        SQL = string.Empty;
        dt = new DataTable();

        try
        {
            SQL = "SELECT COUNT(0)  \n ";
            SQL = SQL + " FROM EDIRECCIONES_ENTREGA, EDESTINOS_POR_RUTA \n ";
            SQL = SQL + " WHERE DIECLAVE = '" + Dieclave + "'   \n ";
            SQL = SQL + "  and der_vilclef(+) = dieville \n ";
            SQL = SQL + "  and die_status = 1 \n ";
            SQL = SQL + "   and NVL(der_tipo_entrega, 'FORANEO 6') = 'FORANEO 6'";

            dt = new BD().ObtieneDataTable(SQL);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (!dt.Rows[0][0].ToString().Trim().Equals(string.Empty))
                    {
                        if (Convert.ToDouble(dt.Rows[0][0].ToString()) > 0)
                        {
                            res = true;
                        }
                    }
                }
            }
        }
        catch
        {
            res = false;
        }
        finally
        {
            if (dt != null)
            {
                dt.Dispose();
                GC.SuppressFinalize(dt);
            }
        }

        return res;
    }
    public bool PorCobrar(string Collect_Prepaid, long Dieclave)
    {
        res = true;
        SQL = string.Empty;
        dt = new DataTable();

        try
        {
            if (Collect_Prepaid == "POR COBRAR")
            {
                SQL = "SELECT COUNT(0) \n ";
                SQL = SQL + " FROM EDIRECCIONES_ENTREGA DIR \n ";
                SQL = SQL + " , ECLIENT_CLIENTE CLICLI \n ";
                SQL = SQL + " WHERE DIR.DIECLAVE = '" + Dieclave + "' \n ";
                SQL = SQL + " AND DIR.DIE_CCLCLAVE = CLICLI.CCLCLAVE \n ";
                SQL = SQL + " AND EXISTS ( \n ";
                SQL = SQL + " SELECT NULL FROM ECIUDADES, EESTADOS WHERE VILCLEF = dieVILLE AND ESTESTADO = VIL_ESTESTADO \n ";
                SQL = SQL + " AND ESTESTADO IN (1129, 1444) ) \n ";
                SQL = SQL + " AND NOT EXISTS ( \n ";
                SQL = SQL + " SELECT NULL FROM ECLIENT, ECREDIT WHERE CLIRFC = CLICLI.CCL_RFC \n ";
                SQL = SQL + " AND CRECLIENT = CLICLEF AND CREREGIME IN (2,6) AND CRE_EMPCLAVE = 28 ) \n ";

                dt = new BD().ObtieneDataTable(SQL);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() != "0")
                        {
                            res = false;
                        }
                    }
                }
            }
        }
        catch
        {
            res = false;
        }
        finally
        {
            if (dt != null)
            {
                dt.Dispose();
                GC.SuppressFinalize(dt);
            }
        }

        return res;
    }
}