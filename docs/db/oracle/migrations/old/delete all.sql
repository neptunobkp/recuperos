alter table "ADMSISREC"."SOLICITUDESVISTO" add ("TransicionId" number(10, 0) null)
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO__973469483"
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO_1500151995"
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO_1005738041"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO_1070111989"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop column "EstadoTDestinoId"
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop column "EstadoTOrigenId"
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_SOLICITUDESVISTO_1157950573" on "ADMSISREC"."SOLICITUDESVISTO" ("TransicionId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."SOLICITUDESVISTO" add constraint "FK_SOLICITUDESVISTO_2000226653" foreign key ("TransicionId") references "ADMSISREC"."TRANSICIONES" ("Id")
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202008062228445_MigNoTransicion') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_USUARIOS_"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."USUARIOS" modify ("NombreIngreso" nvarchar2(200))
/

begin
  execute immediate
  'alter table "ADMSISREC"."USUARIOS" modify ("NombreIngreso" null)';
exception
  when others then
    if sqlcode <> -1442 and sqlcode <> -1451 then
      raise;
    end if;
end;
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202007312207437_MigUsuarioUnico') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO_VisadorId"
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO_1959368914"
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO_2000226653"
/

alter table "ADMSISREC"."SOLICITUDESVISTO" drop constraint "FK_SOLICITUDESVISTO_2000733259"
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO_VisadorId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO_1129843968"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO__979058167"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SOLICITUDESVISTO_1157950573"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."TRANSICIONES" drop column "Aprobable"
/

alter table "ADMSISREC"."SINIESTROS" drop column "EstadoVIsado"
/

drop table "ADMSISREC"."SOLICITUDESVISTO"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_SOLICITUDESVISTO"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202007291838275_MigVisados') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
/

alter table "ADMSISREC"."TERCEROS" drop column "Culpabilidad"
/

alter table "ADMSISREC"."TERCEROS" drop column "Clasificacion"
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202007151808077_MigClasificacionTercero') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
/

alter table "ADMSISREC"."USUARIOS" drop column "Rut"
/

alter table "ADMSISREC"."SINIESTROS" drop column "Daterc"
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202007060025308_MigMigracion') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
/

alter table "ADMSISREC"."TERCEROVEHICULOS" drop constraint "FK_TERCEROVEHICULOS_1813041929"
/

alter table "ADMSISREC"."TERCEROS" drop constraint "FK_TERCEROS_SiniestroId"
/

alter table "ADMSISREC"."INFOVEHICULOS" drop constraint "FK_INFOVEHICULOS_InfoPersonaId"
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" drop constraint "FK_ENTRADASOBSERVAC_1418803507"
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" drop constraint "FK_ENTRADASOBSERVAC_1141287522"
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" drop constraint "FK_ENTRADASOBSERVACI_964300397"
/

alter table "ADMSISREC"."ENTRADASBITACORA" drop constraint "FK_ENTRADASBITACORA_UsuarioId"
/

alter table "ADMSISREC"."ENTRADASBITACORA" drop constraint "FK_ENTRADASBITACORA_1210128694"
/

alter table "ADMSISREC"."ENTRADASBITACORA" drop constraint "FK_ENTRADASBITACORA_1478001279"
/

alter table "ADMSISREC"."ARCHIVOSADJUNTOS" drop constraint "FK_ARCHIVOSADJUNTOS_UsuarioId"
/

alter table "ADMSISREC"."SINIESTROS" drop constraint "FK_SINIESTROS_EstadoId"
/

alter table "ADMSISREC"."TRANSICIONES" drop constraint "FK_TRANSICIONES_EstadoOrigenId"
/

alter table "ADMSISREC"."TRANSICIONES" drop constraint "FK_TRANSICIONES_Esta_574880922"
/

alter table "ADMSISREC"."ESTADOS" drop constraint "FK_ESTADOS_EtapaId"
/

alter table "ADMSISREC"."SINIESTROS" drop constraint "FK_SINIESTROS_EjecutivoId"
/

alter table "ADMSISREC"."ARCHIVOSADJUNTOS" drop constraint "FK_ARCHIVOSADJUNTOS_1140983013"
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_TERCEROVEHICULOS_1458305279"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_TERCEROS_SiniestroId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_INFOVEHICULOS_InfoPersonaId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASOBSERVAC_1392828260"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASOBSERVAC_1362094087"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASOBSERVAC_1973550719"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASBITACORA__477761316"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASBITACORA_UsuarioId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ENTRADASBITACORA_1961181317"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_TRANSICIONES_Est_1210306512"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_TRANSICIONES_EstadoOrigenId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ESTADOS_EtapaId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SINIESTROS_EstadoId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SINIESTROS_EjecutivoId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SINIESTROS_Compania"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_SINIESTROS_Numero"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ARCHIVOSADJUNTOS_UsuarioId"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'drop index "ADMSISREC"."IX_ARCHIVOSADJUNTOS_1647119279"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."TERCEROVEHICULOS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_TERCEROVEHICULOS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."TERCEROS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_TERCEROS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."SINCROS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_SINCROS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."INFOVEHICULOS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_INFOVEHICULOS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."INFOPERSONAS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_INFOPERSONAS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."TIPOSOBSERVACION"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_TIPOSOBSERVACION"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."ENTRADASOBSERVACION"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_ENTRADASOBSERVACION"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."TIPOSBITACORA"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_TIPOSBITACORA"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."ENTRADASBITACORA"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_ENTRADASBITACORA"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."TRANSICIONES"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_TRANSICIONES"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."ETAPAS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_ETAPAS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."ESTADOS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_ESTADOS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."USUARIOS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_USUARIOS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."SINIESTROS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_SINIESTROS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."ARCHIVOSADJUNTOS"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ_ARCHIVOSADJUNTOS"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
/

drop table "ADMSISREC"."__MigrationHistory"
/

begin
  execute immediate
  'drop sequence "ADMSISREC"."SQ___MigrationHistory"';
exception
  when others then
    if sqlcode <> -2289 then
      raise;
    end if;
end;
