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
  'drop index "ADMSISREC"."IX_SINIESTROS_Numero_Riesgo"';
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
