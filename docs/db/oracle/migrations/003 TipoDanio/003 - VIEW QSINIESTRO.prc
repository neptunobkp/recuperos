CREATE OR REPLACE FORCE VIEW ADMSISREC.QSINIESTROMC
AS
   SELECT
         SIN."Id",
          SIN."Numero",
          SIN."Compania",
          SIN."Riesgo",
          SIN."FechaDenuncio",
          SIN."FechaSiniestro",
          SIN."FechaAsignacion",
          SIN."EjecutivoId",
          usu."Nombres"                          "EjecutivoNombres",
          SIN."FechaUltimoCambioEstado",
          SIN."EstadoId",
          est."DiasAlerta"                       "EstadoDiasAlerta",
          est."Nombre"                           "EstadoNombre",
          est."EtapaId"                          "EtapaId",
          SIN."CompaniaTercero",
          SIN."Region",
          TRUNC ( (SYSDATE - TRUNC (NVL (SIN."FechaAsignacion", SYSDATE))))
             "DiasGestion",
          CASE
             WHEN TRUNC ((SYSDATE - TRUNC (NVL (SIN."FechaAsignacion", SYSDATE)))) >= est."DiasAlerta" THEN 2
             WHEN TRUNC ((SYSDATE - TRUNC (NVL (SIN."FechaAsignacion", SYSDATE)))) >= est."DiasAdvertencia" THEN 1
             WHEN TRUNC ((SYSDATE - TRUNC (NVL (SIN."FechaAsignacion", SYSDATE)))) >= est."DiasInfo" THEN 0
             ELSE  -1
          END
             "AlertaGestion",
          SIN."Probabilidad",
          TRUNC (SYSDATE - SIN."FechaSiniestro") "Prescripcion",
          SIN."Daterc",
          SIN."EstadoVisado",
          SIN."ActualizadoPor",
          svies."Nombre"                         "EstadoDestinoNombre",
          NVL(SIN."GastoUf",0) "GastoUf",
          SIN."TipoOrden",
          NVL(SIN."MontoOr",0) "MontoOr",
          NVL(SIN."Provision",0) "Provision",
          Decode(SIN."Aceptado",1,'A',null) as "Aceptado",
          SIN."TipoDanio"
     FROM siniestros SIN
          LEFT OUTER JOIN USUARIOS usu ON usu."Id" = SIN."EjecutivoId"
          LEFT OUTER JOIN SOLICITUDESVISTO svi
             ON     svi."SiniestroId" = SIN."Id"
                AND svi."Id" = SIN."EstadoVisado"
          LEFT OUTER JOIN ESTADOS svies
             ON svies."Id" = svi."EstadoTDestinoId"
          JOIN ESTADOS est ON est."Id" = SIN."EstadoId";
