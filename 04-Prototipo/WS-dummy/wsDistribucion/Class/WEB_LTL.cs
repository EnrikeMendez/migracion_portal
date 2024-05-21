using System;
using System.Data;
using System.Runtime.CompilerServices;

public class WEB_LTL
{
    #region Variables
    BD bd = new BD();
    DataTable dt = null;
    Respuesta resp = null;
    ClsFunciones fn = null;
    string SQL = string.Empty;

    private string _created_by;
    private DateTime _date_created;
    private DateTime _date_modified;
    private string _modified_by;
    private long _welcdad_cajas;
    private long _welcdad_remisiones;
    private long _welclave;
    private long _welcons_general;
    private string _welentrega_domicilio;
    private string _welfactura;
    private double _welimporte;
    private string _welobservacion;
    private double _welpeso;
    private string _welrecol_domicilio;
    private int _welstatus;
    private double _welvolumen;
    private long _wel_allclave_dest;
    private long _wel_allclave_ori;
    private string _wel_a_cargo_de;
    private long _wel_cajas_tarimas;
    private long _wel_cdad_bultos;
    private long _wel_cdad_tarimas;
    private long _wel_cliclef;
    private string _wel_collect_prepaid;
    private string _wel_contacto_ocurre_logis;
    private long _wel_dieclave;
    private long _wel_disclef;
    private long _wel_dxpclave_recol;
    private DateTime _wel_fecha_recoleccion;
    private string _wel_firma;
    private string _wel_ip;
    private string _wel_validacion_status;
    private int _wel_manif_corte;
    private DateTime _wel_manif_fecha;
    private long _wel_manif_num;
    private string _wel_orden_compra;
    private string _wel_talon_rastreo;
    private long _wel_wcclclave;
    private long _wel_wtlclave;
    private long _wel_id_op;
    #endregion

    #region Métodos
    public string Created_By
    {
        get => _created_by;
        set
        {
            _created_by = value;
        }
    }
    public DateTime Date_Created
    {
        get => _date_created;
        set
        {
            _date_created = value;
        }
    }
    public DateTime Date_Modified
    {
        get => _date_modified;
        set
        {
            _date_modified = value;
        }
    }
    public string Modified_By
    {
        get => _modified_by;
        set
        {
            _modified_by = value;
        }
    }
    public long Welcdad_Cajas
    {
        get => _welcdad_cajas;
        set
        {
            _welcdad_cajas = value;
        }
    }
    public long Welcdad_Remisiones
    {
        get => _welcdad_remisiones;
        set
        {
            _welcdad_remisiones = value;
        }
    }
    public long Welclave
    {
        get => _welclave;
        set
        {
            _welclave = value;
        }
    }
    public long Welcons_General
    {
        get => _welcons_general;
        set
        {
            _welcons_general = value;
        }
    }
    public string Welentrega_Domicilio
    {
        get => _welentrega_domicilio;
        set
        {
            _welentrega_domicilio = value;
        }
    }
    public string Welfactura
    {
        get => _welfactura;
        set
        {
            _welfactura = value;
        }
    }
    public double Welimporte
    {
        get => _welimporte;
        set
        {
            _welimporte = value;
        }
    }
    public string Welobservacion
    {
        get => _welobservacion;
        set
        {
            _welobservacion = value;
        }
    }
    public double Welpeso
    {
        get => _welpeso;
        set
        {
            _welpeso = value;
        }
    }
    public string Welrecol_Domicilio
    {
        get => _welrecol_domicilio;
        set
        {
            _welrecol_domicilio = value;
        }
    }
    public int Welstatus
    {
        get => _welstatus;
        set
        {
            _welstatus = value;
        }
    }
    public double Welvolumen
    {
        get => _welvolumen;
        set
        {
            _welvolumen = value;
        }
    }
    public long Wel_Allclave_Dest
    {
        get => _wel_allclave_dest;
        set
        {
            _wel_allclave_dest = value;
        }
    }
    public long Wel_Allclave_Ori
    {
        get => _wel_allclave_ori;
        set
        {
            _wel_allclave_ori = value;
        }
    }
    public string Wel_A_Cargo_De
    {
        get => _wel_a_cargo_de;
        set
        {
            _wel_a_cargo_de = value;
        }
    }
    public long Wel_Cajas_Tarimas
    {
        get => _wel_cajas_tarimas;
        set
        {
            _wel_cajas_tarimas = value;
        }
    }
    public long Wel_Cdad_Bultos
    {
        get => _wel_cdad_bultos;
        set
        {
            _wel_cdad_bultos = value;
        }
    }
    public long Wel_Cdad_Tarimas
    {
        get => _wel_cdad_tarimas;
        set
        {
            _wel_cdad_tarimas = value;
        }
    }
    public long Wel_Cliclef
    {
        get => _wel_cliclef;
        set
        {
            _wel_cliclef = value;
        }
    }
    public string Wel_Collect_Prepaid
    {
        get => _wel_collect_prepaid;
        set
        {
            _wel_collect_prepaid = value;
        }
    }
    public string Wel_Contacto_Ocurre_Logis
    {
        get => _wel_contacto_ocurre_logis;
        set
        {
            _wel_contacto_ocurre_logis = value;
        }
    }
    public long Wel_Dieclave
    {
        get => _wel_dieclave;
        set
        {
            _wel_dieclave = value;
        }
    }
    public long Wel_Disclef
    {
        get => _wel_disclef;
        set
        {
            _wel_disclef = value;
        }
    }
    public long Wel_Dxpclave_Recol
    {
        get => _wel_dxpclave_recol;
        set
        {
            _wel_dxpclave_recol = value;
        }
    }
    public DateTime Wel_Fecha_Recoleccion
    {
        get => _wel_fecha_recoleccion;
        set
        {
            _wel_fecha_recoleccion = value;
        }
    }
    public string Wel_Firma
    {
        get => _wel_firma;
        set
        {
            _wel_firma = value;
        }
    }
    public string Wel_ip
    {
        get => _wel_ip;
        set
        {
            _wel_ip = value;
        }
    }
    public int Wel_Manif_Corte
    {
        get => _wel_manif_corte;
        set
        {
            _wel_manif_corte = value;
        }
    }
    public DateTime Wel_Manif_Fecha
    {
        get => _wel_manif_fecha;
        set
        {
            _wel_manif_fecha = value;
        }
    }
    public long Wel_Manif_Num
    {
        get => _wel_manif_num;
        set
        {
            _wel_manif_num = value;
        }
    }
    public string Wel_Orden_Compra
    {
        get => _wel_orden_compra;
        set
        {
            _wel_orden_compra = value;
        }
    }
    public string Wel_Talon_Rastreo
    {
        get => _wel_talon_rastreo;
        set
        {
            _wel_talon_rastreo = value;
        }
    }
    public string Wel_Validacion_Status
    {
        get => _wel_validacion_status;
        set
        {
            _wel_validacion_status = value;
        }
    }
    public long Wel_Wcclclave
    {
        get => _wel_wcclclave;
        set
        {
            _wel_wcclclave = value;
        }
    }
    public long Wel_Wtlclave
    {
        get => _wel_wtlclave;
        set
        {
            _wel_wtlclave = value;
        }
    }
    public long Wel_ID_OP
    {
        get => _wel_id_op;
        set
        {
            _wel_id_op = value;
        }
    }
    #endregion

    #region Funciones
    public Respuesta ValidaInfo(WEB_LTL Info)
    {
        resp = new Respuesta();
        fn = new ClsFunciones();

        try
        {
            resp.Ok = true;
            resp.Codigo = 0;
            resp.Mensaje = string.Empty;

            if (Info.Wel_Dieclave <= 0 || Info.Wel_Cdad_Bultos <= 0)
            {
                resp.Ok = false;
                resp.Codigo = -1;
                resp.Mensaje = "Error: Favor de capturar el destinatario y la cdad de bultos.";
            }
            else if (Info.Wel_Allclave_Ori <= 0 || Info.Wel_Disclef <= 0)
            {
                resp.Ok = false;
                resp.Codigo = -2;
                resp.Mensaje = "Error: Favor de validar la información del Distribuidor y el Almacén de Origen.";
            }
            else if (Info.Welimporte <= 0)
            {
                if (fn.ClienteConSeguro(Info.Wel_Cliclef))
                {
                    resp.Ok = false;
                    resp.Codigo = -3;
                    resp.Mensaje = "Error: Cliente con tarifa de seguro, el Valor de la Mercancía debe ser mayor a cero.";
                }
            }
            else if (fn.Foraneo6(Info.Wel_Dieclave) == true)
            {
                resp.Ok = false;
                resp.Codigo = -4;
                resp.Mensaje = "Error: Esta ciudad es FORANEO 6, no se puede crear el talon con este proceso.";
            }
            else if (fn.PorCobrar(Info.Wel_Collect_Prepaid, Info.Wel_Dieclave) == false)
            {
                resp.Ok = false;
                resp.Codigo = -5;
                resp.Mensaje = "Error: LTL no creada. No se puede hacer una LTL POR COBRAR en el Distrito Federal o sus cercanias!";
            }
        }
        catch (Exception ex)
        {
            resp.Ok = false;
            resp.Codigo = -6;
            resp.Objeto = null;
            resp.Mensaje = fn.ObtieneMensajeExcepcion(ex);
        }

        return resp;
    }
    public Respuesta DocumentaTalon(WEB_LTL Info)
    {
        bd = new BD();
        SQL = string.Empty;
        resp = new Respuesta();

        try
        {
            //1.- Buscar el siguiente NUI disponible para esta cuenta:


            //2.- Documentar el Talón en base al NUI que se encontró disponible:
            SQL = string.Format("{0} UPDATE WEB_LTL \n", SQL);
            SQL = string.Format("{0} 	SET \n", SQL);
            SQL = string.Format("{0}		 WEL_ALLCLAVE_ORI		=	'{1}' \n", SQL, Info.Wel_Allclave_Ori);
            SQL = string.Format("{0}		,WEL_DISCLEF			=	'{1}' \n", SQL, Info.Wel_Disclef);
            SQL = string.Format("{0}		,WEL_DIECLAVE			=	'{1}' \n", SQL, Info.Wel_Dieclave);
            SQL = string.Format("{0}		,WEL_ALLCLAVE_DEST		=	 NVL('{1}', 1) \n", SQL, Info.Wel_Allclave_Dest);
            SQL = string.Format("{0}		,WEL_FECHA_RECOLECCION	=	 TO_DATE({1},'DD/MM/YYYY HH24:MI:SS')  \n", SQL, Info.Wel_Fecha_Recoleccion.ToString("dd/MM/yyyy HH:mm:ss"));
            SQL = string.Format("{0}		,WELFACTURA				=	'{1}' \n", SQL, Info.Welfactura);
            SQL = string.Format("{0}		,WEL_ORDEN_COMPRA		=	'{1}' \n", SQL, Info.Wel_Orden_Compra);
            SQL = string.Format("{0}		,WELIMPORTE				=	 {1}  \n", SQL, Info.Welimporte);
            SQL = string.Format("{0}		,WELCDAD_REMISIONES		=	 {1}  \n", SQL, Info.Welcdad_Remisiones);
            SQL = string.Format("{0}		,WELRECOL_DOMICILIO		=	'{1}' \n", SQL, Info.Welrecol_Domicilio);
            SQL = string.Format("{0}		,WELENTREGA_DOMICILIO	=	'{1}' \n", SQL, Info.Welentrega_Domicilio);
            SQL = string.Format("{0}		,WEL_CDAD_BULTOS		=	 TO_NUMBER({1}) \n", SQL, Info.Wel_Cdad_Bultos);
            SQL = string.Format("{0}		,WELPESO				=	 {1} \n", SQL, Info.Welpeso);

            /* Si no se tiene Observacion, poner _PENDIENTE_ */
            if (Info.Welobservacion.Trim().Equals(string.Empty))
            {
                SQL = string.Format("{0}		,WELOBSERVACION			=	(SELECT UPPER(NVL(LOGIS.GET_CLI_LTL_OBSERVACIONES({1}),'_PENDIENTE_')) FROM DUAL) \n", SQL, Info.Wel_Cliclef);
            }
            else
            {
                SQL = string.Format("{0}		,WELOBSERVACION			=	 REPLACE(UPPER('{1}' || DECODE({2}, NULL, NULL, \n {2})), '|', NULL) \n", SQL, Info.Welobservacion, "(SELECT LOGIS.GET_CLI_LTL_OBSERVACIONES(" + Info.Wel_Cliclef + ") FROM DUAL)");
            }

            SQL = string.Format("{0}		,MODIFIED_BY				=	 SUBSTR(UPPER('{1}')|| '-WS_ENC', 1, 30) \n", SQL, Info.Created_By);
            SQL = string.Format("{0}		,DATE_MODIFIED				=	 TO_DATE({1},'DD/MM/YYYY HH24:MI:SS') \n", SQL, Info.Date_Created.ToString("dd/MM/yyyy HH:mm:ss"));
            SQL = string.Format("{0}		,DATE_CREATED				=	 SYSDATE \n", SQL);
            SQL = string.Format("{0}		,WELVOLUMEN					=	 {1}  \n", SQL, Info.Welvolumen);
            SQL = string.Format("{0}		,WEL_COLLECT_PREPAID		=	 NVL('{1}', 'PREPAGADO') \n", SQL, Info.Wel_Collect_Prepaid);
            SQL = string.Format("{0}		,WEL_MANIF_NUM				=	'{1}' \n", SQL, Info.Wel_Manif_Num);
            SQL = string.Format("{0}		,WEL_MANIF_FECHA			=	 TO_DATE({1},'DD/MM/YYYY HH24:MI:SS') \n", SQL, Info.Wel_Manif_Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
            SQL = string.Format("{0}		,WEL_DXPCLAVE_RECOL			=	'{1}' \n", SQL, Info.Wel_Dxpclave_Recol);

            /* Si no se tiene IP, se mantiene la original */
            if (!Info.Wel_ip.Trim().Equals(string.Empty))
            {
                try
                {
                    //SQL = string.Format("{0}		,WEL_IP						=	'{1}' \n", SQL, this.Request.HttpContext.Items["REMOTE_ADDR"]);
                    SQL = string.Format("{0}		,WEL_IP						=	'{1}' \n", SQL, Info.Wel_ip);
                }
                catch { }
            }

            SQL = string.Format("{0}		,WEL_MANIF_CORTE			=	 {1} \n", SQL, Info.Wel_Manif_Corte);
            SQL = string.Format("{0}		,WELSTATUS					=	 {1} \n", SQL, Info.Welstatus);
            SQL = string.Format("{0}		,WEL_CDAD_TARIMAS			=	 {1} \n", SQL, Info.Wel_Cdad_Tarimas);
            SQL = string.Format("{0}		,WEL_CAJAS_TARIMAS			=	 {1} \n", SQL, Info.Wel_Cajas_Tarimas);
            SQL = string.Format("{0}		,WELCDAD_CAJAS				=	 {1} \n", SQL, Info.Welcdad_Cajas);
            SQL = string.Format("{0}		,WEL_CONTACTO_OCURRE_LOGIS	=	'{1}' \n", SQL, Info.Wel_Contacto_Ocurre_Logis);
            SQL = string.Format("{0} WHERE	 WEL_CLICLEF		=	'{1}' \n", SQL, Info.Wel_Cliclef);
            SQL = string.Format("{0}		 AND	WELCLAVE	=	'{1}' \n", SQL, Info.Welclave);

            bd.EjecutarQuery(SQL);

            Info = new WEB_LTL();

            // Siguientes partes del flujo de documentación:

        }
        catch (Exception ex)
        {
            resp.Ok = false;
            resp.Codigo = -7;
            resp.Objeto = null;
            resp.Mensaje = fn.ObtieneMensajeExcepcion(ex);
        }

        return resp;
    }

    public Respuesta Consulta_Talon(WEB_LTL Info)
    {
        resp = new Respuesta();

        try
        {
            SQL = string.Empty;
            SQL = string.Format("{0}SELECT \n", SQL);
            SQL = string.Format("{0}	 CREATED_BY \n", SQL);
            SQL = string.Format("{0}	,TO_CHAR(DATE_CREATED,'DD/MM/YYYY HH24:MI:SS') DATE_CREATED \n", SQL);
            SQL = string.Format("{0}	,TO_CHAR(DATE_MODIFIED,'DD/MM/YYYY HH24:MI:SS') DATE_MODIFIED \n", SQL);
            SQL = string.Format("{0}	,MODIFIED_BY \n", SQL);
            SQL = string.Format("{0}	,WEL_A_CARGO_DE \n", SQL);
            SQL = string.Format("{0}	,WEL_ALLCLAVE_DEST \n", SQL);
            SQL = string.Format("{0}	,WEL_ALLCLAVE_ORI \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_CAJAS_TARIMAS,0) WEL_CAJAS_TARIMAS \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_CDAD_BULTOS,0) WEL_CDAD_BULTOS \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_CDAD_TARIMAS,0) WEL_CDAD_TARIMAS \n", SQL);
            SQL = string.Format("{0}	,WEL_CLICLEF \n", SQL);
            SQL = string.Format("{0}	,WEL_COLLECT_PREPAID \n", SQL);
            SQL = string.Format("{0}	,WEL_CONTACTO_OCURRE_LOGIS \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_DIECLAVE,0) WEL_DIECLAVE \n", SQL);
            SQL = string.Format("{0}	,WEL_DISCLEF \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_DXPCLAVE_RECOL,0) WEL_DXPCLAVE_RECOL \n", SQL);
            SQL = string.Format("{0}	,WEL_FECHA_RECOLECCION \n", SQL);
            SQL = string.Format("{0}	,WEL_FIRMA \n", SQL);
            SQL = string.Format("{0}	,WEL_IP \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_MANIF_CORTE,0) WEL_MANIF_CORTE \n", SQL);
            SQL = string.Format("{0}	,WEL_MANIF_FECHA \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_MANIF_NUM,0) WEL_MANIF_NUM \n", SQL);
            SQL = string.Format("{0}	,WEL_ORDEN_COMPRA \n", SQL);
            SQL = string.Format("{0}	,WEL_TALON_RASTREO \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_WCCLCLAVE,0) WEL_WCCLCLAVE \n", SQL);
            SQL = string.Format("{0}	,WEL_WTLCLAVE \n", SQL);
            SQL = string.Format("{0}	,NVL(WELCDAD_CAJAS,0) WELCDAD_CAJAS \n", SQL);
            SQL = string.Format("{0}	,NVL(WELCDAD_REMISIONES,0) WELCDAD_REMISIONES \n", SQL);
            SQL = string.Format("{0}	,WELCLAVE \n", SQL);
            SQL = string.Format("{0}	,WELCONS_GENERAL \n", SQL);
            SQL = string.Format("{0}	,WELENTREGA_DOMICILIO \n", SQL);
            SQL = string.Format("{0}	,WELFACTURA \n", SQL);
            SQL = string.Format("{0}	,NVL(WELIMPORTE,0) WELIMPORTE \n", SQL);
            SQL = string.Format("{0}	,WELOBSERVACION \n", SQL);
            SQL = string.Format("{0}	,NVL(WELPESO,0) WELPESO \n", SQL);
            SQL = string.Format("{0}	,WELRECOL_DOMICILIO \n", SQL);
            SQL = string.Format("{0}	,WELSTATUS \n", SQL);
            SQL = string.Format("{0}	,NVL(WELVOLUMEN,0) WELVOLUMEN \n", SQL);
            SQL = string.Format("{0}	,NVL(WEL_ID_OP,0) WEL_ID_OP \n", SQL);
            SQL = string.Format("{0}	,WEL_VALIDACION_STATUS \n", SQL);
            SQL = string.Format("{0}FROM	WEB_LTL \n", SQL);
            SQL = string.Format("{0}WHERE	WELCLAVE	=	'{1}' \n", SQL, Info.Welclave);

            dt = bd.ObtieneDataTable(SQL);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Info.Wel_ip = dt.Rows[0]["WEL_IP"].ToString();
                    Info.Wel_Firma = dt.Rows[0]["WEL_FIRMA"].ToString();
                    Info.Created_By = dt.Rows[0]["CREATED_BY"].ToString();
                    Info.Welfactura = dt.Rows[0]["WELFACTURA"].ToString();
                    Info.Modified_By = dt.Rows[0]["MODIFIED_BY"].ToString();
                    Info.Wel_A_Cargo_De = dt.Rows[0]["WEL_A_CARGO_DE"].ToString();
                    Info.Welobservacion = dt.Rows[0]["WELOBSERVACION"].ToString();
                    Info.Wel_Orden_Compra = dt.Rows[0]["WEL_ORDEN_COMPRA"].ToString();
                    Info.Wel_Talon_Rastreo = dt.Rows[0]["WEL_TALON_RASTREO"].ToString();
                    Info.Welrecol_Domicilio = dt.Rows[0]["WELRECOL_DOMICILIO"].ToString();
                    Info.Wel_Collect_Prepaid = dt.Rows[0]["WEL_COLLECT_PREPAID"].ToString();
                    Info.Welentrega_Domicilio = dt.Rows[0]["WELENTREGA_DOMICILIO"].ToString();
                    Info.Wel_Validacion_Status = dt.Rows[0]["WEL_VALIDACION_STATUS"].ToString();
                    Info.Wel_Contacto_Ocurre_Logis = dt.Rows[0]["WEL_CONTACTO_OCURRE_LOGIS"].ToString();

                    Info.Welstatus = Convert.ToInt32(dt.Rows[0]["WELSTATUS"].ToString());
                    Info.Wel_Manif_Corte = Convert.ToInt32(dt.Rows[0]["WEL_MANIF_CORTE"].ToString());

                    Info.Welclave = Convert.ToInt64(dt.Rows[0]["WELCLAVE"].ToString());
                    Info.Wel_ID_OP = Convert.ToInt64(dt.Rows[0]["WEL_ID_OP"].ToString());
                    Info.Wel_Cliclef = Convert.ToInt64(dt.Rows[0]["WEL_CLICLEF"].ToString());
                    Info.Wel_Disclef = Convert.ToInt64(dt.Rows[0]["WEL_DISCLEF"].ToString());
                    Info.Wel_Dieclave = Convert.ToInt64(dt.Rows[0]["WEL_DIECLAVE"].ToString());
                    Info.Wel_Wtlclave = Convert.ToInt64(dt.Rows[0]["WEL_WTLCLAVE"].ToString());
                    Info.Wel_Manif_Num = Convert.ToInt64(dt.Rows[0]["WEL_MANIF_NUM"].ToString());
                    Info.Wel_Wcclclave = Convert.ToInt64(dt.Rows[0]["WEL_WCCLCLAVE"].ToString());
                    Info.Welcdad_Cajas = Convert.ToInt64(dt.Rows[0]["WELCDAD_CAJAS"].ToString());
                    Info.Welcons_General = Convert.ToInt64(dt.Rows[0]["WELCONS_GENERAL"].ToString());
                    Info.Wel_Cdad_Bultos = Convert.ToInt64(dt.Rows[0]["WEL_CDAD_BULTOS"].ToString());
                    Info.Wel_Allclave_Ori = Convert.ToInt64(dt.Rows[0]["WEL_ALLCLAVE_ORI"].ToString());
                    Info.Wel_Cdad_Tarimas = Convert.ToInt64(dt.Rows[0]["WEL_CDAD_TARIMAS"].ToString());
                    Info.Wel_Allclave_Dest = Convert.ToInt64(dt.Rows[0]["WEL_ALLCLAVE_DEST"].ToString());
                    Info.Wel_Cajas_Tarimas = Convert.ToInt64(dt.Rows[0]["WEL_CAJAS_TARIMAS"].ToString());
                    Info.Wel_Dxpclave_Recol = Convert.ToInt64(dt.Rows[0]["WEL_DXPCLAVE_RECOL"].ToString());
                    Info.Welcdad_Remisiones = Convert.ToInt64(dt.Rows[0]["WELCDAD_REMISIONES"].ToString());

                    Info.Welpeso = Convert.ToDouble(dt.Rows[0]["WELPESO"].ToString());
                    Info.Welimporte = Convert.ToDouble(dt.Rows[0]["WELIMPORTE"].ToString());
                    Info.Welvolumen = Convert.ToDouble(dt.Rows[0]["WELVOLUMEN"].ToString());

                    if (dt.Rows[0]["DATE_CREATED"].ToString() != string.Empty)
                    {
                        Info.Date_Created = Convert.ToDateTime(dt.Rows[0]["DATE_CREATED"].ToString());
                    }
                    if (dt.Rows[0]["DATE_MODIFIED"].ToString() != string.Empty)
                    {
                        Info.Date_Modified = Convert.ToDateTime(dt.Rows[0]["DATE_MODIFIED"].ToString());
                    }
                    if (dt.Rows[0]["WEL_MANIF_FECHA"].ToString() != string.Empty)
                    {
                        Info.Wel_Manif_Fecha = Convert.ToDateTime(dt.Rows[0]["WEL_MANIF_FECHA"].ToString());
                    }
                    if (dt.Rows[0]["WEL_FECHA_RECOLECCION"].ToString() != string.Empty)
                    {
                        Info.Wel_Fecha_Recoleccion = Convert.ToDateTime(dt.Rows[0]["WEL_FECHA_RECOLECCION"].ToString());
                    }

                    resp.Ok = true;
                    resp.Codigo = 0;
                    resp.Objeto = Info;
                    resp.Mensaje = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            resp.Ok = false;
            resp.Codigo = -8;
            resp.Objeto = null;
            resp.Mensaje = fn.ObtieneMensajeExcepcion(ex);
        }

        return resp;
    }
    #endregion
}