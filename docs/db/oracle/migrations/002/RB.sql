begin
  execute immediate
  'drop index "ADMSISREC"."IX_SINIESTROS_"';
exception
  when others then
    if sqlcode <> -1418 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."TERCEROS" drop column "DireccionAlt"
/

alter table "ADMSISREC"."ESTADOS" drop column "EstrategiaCalculo"
/

alter table "ADMSISREC"."ESTADOS" drop column "DiasAdvertencia"
/

alter table "ADMSISREC"."ESTADOS" drop column "DiasInfo"
/

delete "ADMSISREC"."__MigrationHistory"
where (("MigrationId" = '202011130457261_MigQSiniestros') and ("ContextKey" = 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration'))
