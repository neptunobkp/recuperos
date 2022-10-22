update transiciones set "Aprobable" = 1 where "Id" in (select "Id" from transiciones where 
"EstadoDestinoId" in ( select "Id" from estados where "EtapaId" = 30 ) and 
"EstadoOrigenId" not in ( select "Id" from estados where "EtapaId" = 30 ));

update transiciones set "Aprobable" = 1 where "Id" in (select "Id" from transiciones where 
"EstadoDestinoId" in ( select "Id" from estados where "EtapaId" = 29 ) and 
"EstadoOrigenId" not in ( select "Id" from estados where "EtapaId" = 29 ));

COMMIT;