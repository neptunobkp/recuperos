﻿alter table "ADMSISREC"."ESTADOS" add ("DiasInfo" number(10, 0) null)
/

alter table "ADMSISREC"."ESTADOS" add ("DiasAdvertencia" number(10, 0) null)
/

alter table "ADMSISREC"."ESTADOS" add ("EstrategiaCalculo" number(10, 0) null)
/

alter table "ADMSISREC"."TERCEROS" add ("DireccionAlt" nvarchar2(200) null)
/

begin
  execute immediate
  'create unique index "ADMSISREC"."IX_SINIESTROS_Numero_Riesgo" on "ADMSISREC"."SINIESTROS" ("Numero", "Riesgo")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

declare
model_blob blob;
begin
dbms_lob.createtemporary(model_blob, true);
dbms_lob.append(model_blob, to_blob(cast('1F8B0800000000000400ED3DDB72DB3A92EF5BB5FFA0D2E354C68A73F69C3A49D933A548CE39DA892FB1ECD4BEB9600A963943911A924A393B355F360FF349FB0B0BDE71BF900029392ABF58B834D0CD46A3D1E86EFCDFBFFE7DF6E7974D30FA06E3C48FC2F3F1E9C9DBF108865EB4F2C3F5F978973EFDF1D7F19FFFF49FFF7176B1DABC8CBE56ED7ECADAA19E61723E7E4ED3ED87C924F19EE10624271BDF8BA3247A4A4FBC683301AB68F2EEEDDBF793D3D3094420C608D6687476BB0B537F03F31FE8E72C0A3DB84D7720B88C563048CA7254B3CCA18EAEC006265BE0C1F3F12DF4765B888638B9C96693A468BA3E38F90812781D032F80E3D134F0019AD812064FE31108C32805299AF687FB042ED3380AD7CB2D2A00C1DDF72D44ED9E4090C0129D0F4D735DCCDEBECB309B341D2B50DE2E49A38D21C0D39F4A524DE8EEAD083EAE4989887981889E7ECFB0CE097A3E9EC6DEB3FF2D9AAEFE8ABE47341ED1437E980571D61CA77AFE85A2930CD60AAC607242027933A29BBEA9D9067157F6F76634DB05E92E86E721DCA53108DE8C6E768F81EFFD057EBF8BFE06C3F3701704F8CCD1DC511D51808A6EE2088D937EBF854F253E8BD5783421FB4DE88E7537AC4F81E3224C7F7A371E5DA1C1C163006BC6C0E8B14CA318FE0643188314AE6E409AC238CC60C09CB4CCE8D4584B3FF4618258503DA81CD027E83D830AC41CCDE50EAD266328F7C90EC47EE7C95C459BC7185630D00A43B2633CBA042F9F61B84E9FCFC7881FC7A34FFE0B5C552525DCFBD047A206754AE39D72988B17B4D4937C214846B230D07D1C488678FFFEBD0D64027FE38768B156237D8CA20082504DFC2BF0CD5FE7DC2862AE315A8241DE2279F6B7851C3CA96B1FCAF59A202CE268731B0578DFBAF6E10EC46B98A2E945C226CB68177B06332CF98D3B3F528A3CD44D9B39F25BD493A8E6296856A183CFF56CD24844A99CC448DB4A44D6FD8FD2512647761B1847DD64D12DA2F3BA238C5CB8CE61B8438A45C40A598DCE18BFB4E83D4DFC75083C4CD2E976BF8961E2C5FEB64DDF7CE8FB00A96560EA65AA98FFBF8239B421E762B38DE2D422C07CA6D10C6C1EFDE8224931496A8E700526055BCEA6AA01A55AD4A69D6FC126926C35A756F6CD59B4D982D007DD1605FAF9081EFD2093689D217DF3F17D7C0E3DC47468CF45ECEBF9E541E4D7F168E9810CE83B15C0DF0012C9F74FB6C05D4668DFB88E292415DBF95F1107A468DB61E4A5A25FCEB9869D66E874B68E963B6F172740A6AA9C5AE09E3B7F1BCD230F89E6FC84E074AC6203B88932D18351E497FF32574973488B146EBAF16A8E3D5A3C52CC7FB644E6EB186D94AE079A66076D9EDEA9EA566E092BF47D62997A6C4364CDD1E609BC36DA31777D7DF5130C96E61A2B84E61D44CA65EC5E48DFC2352611B5A658F0' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('383541AD9EF99E85CA363031DEEF72E96834DA1D0CE05314BAA7618ED60C2035A315524B24773C3F35E514C462BB951F4D1FA335EA9A38C732C329F6EC9FB685A7B6E6BC68E358491FD724274FDD09D69BAF6286583BDE14EB6AC91C9B36C6932C7554F90CCB46DCE9E575B2B9150D4C2756B2FD0E9D53919C4C0553AC1AE54D1EB0F30D3655411BD692206AC8B327689FD16B8B41AB137AD9FB783E57DAF96412CE8EA1AF186711AED160B25D437734439D6116C531B431AE6A9810714F0243E07C28B4ECDC8FB14B2563FC6C774BC26456FE6F0AC2147205576325E4F668A497B4212375E5ADBB896024C4635D5CEAE65244CA563A58544DBB994B0901DFD6664A00390A66A5CDB1A25767FB5AA148DC5DC7FE1A865D2F874A60D989CE0F3B5F35DDC070E5C37CE9763B184EB7993DABFB01D3DA8DDE1CA6200864B768E8F860ED94449E88758F49D50909D1DFD064558A15552F85F65C71918E8A4AF710EAA9644356BF96B66E770A289796011A55071516453B4D24CAC6C6BB95FC9EB1CB4941316FF64861B8C3BA5613E8938E9E52A18B8453DD4063EAB41AD14A37A88EB8AD7482A2F35117E8E28C61C70A95DF9575DEF37C904C038819ECB43693ACDB227C3233D3E563ADBEA192DC5FCCD4C4977D8CB50F6620F07681A181D0BEAB477953C99103794D29E009531C51C1AC76B2D65430DDC5204CFCEC6E1726B22DBAB250F19A633315B662F6074953D31D028721D99E3923B27BB3B0910E02925D595FC816FCD14EC6667D8F22760F44AC03B951C985F69283E160AE5C69C5B5CD2A68C9BA0D8023FF2A8FE4368FF7964EF7C5A1FCB139058B2EA7150CEE740F62B64EF57665367B77BB8FC6D4A97DAADDEE9319B657E0233A6F7951DC7A1F22A11C57741F56284B1EE176DCD37FCF9947B2CB5AF2BBA958CCBD09AFA5EF784B530CB582F8B618612376A717B634D6B531A26BCD9CEC209E3CDE4E397FA2B1290A3257767A208E2FBBA08972CE56BCD9496AB6D3B4301047C9DCE5AC602936A6DD59C1744BBF7E4C60FC0D7450D1594047F6396EEC8E36768CCB5EE9DE8E6128DDDEB9ED44BB0DBF719B4D9E90177A5830DDA4B850AD7530A2BB38D8F971F0E2CD9FD34A67FED65480EEC29C827294E4AF5F11C8EE5D6ED0378D4243D5F12523577482F53FB28B9E3B5D97A06CF7CE9A733F861E1ED6C719E9174B0E93BDF8656A842BD819A8B2DC391EA6888A40DB145A492D5437B137027CF6B3BB50FE6D42B6CEAB160F84D068F641511BC64E296CD8C94C89436D2DCB2A00476126F3DA43BD309F3D67AC7E0962CFBD3775F1799D0FF31994FCE37CA42916DFA8191C174863002D8501E4F16D9751DADB58B36790F8EEB7CC8E1279986D0413BBADBD38897DC0F6A6411F9D94BB4BAB4DE34BBB54205F763046DD4EBE1C3381F49509C44EDA83' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('1F3B9F48EBB406553FF52904FD6B4BA4764F09D22A1D831557C8D271A19D4364D1596961B0436AFDC8783BE3B5888CCFC8F85BE68361D8AF207D9B9E3716B3A3B0297CF49056C585DBF91CDA8920EC0C4738F4F4C4E16EF3C9740577633B7D0E9D11C4195D75729CB419C9248D9BD725879BF783AA6D5751D896E4F52ED1EE82A1E8FD4312BDF72BE2BE2CC69D4DDB3A2667CBC6ED69208B6EB79510A0A7BC03D9307D20D49B25BD1AA80FA4F2DCD2EE3F520012FFC9F780B11A88C4E056A089AA34AD1B848CE76F9B9472AE73D296E29DEFB9C05432161EB685E95D7E63FE17CFAEB621D55B193347BA097381216AD7E9FE8202DA6D8BDD8B7B0C6A2E6D765E0E884EA7B1E3CD859B9B0B4B87D1E3CD85DB9B0BB17757250CED0A4E8188170A581DC1394D92C8F3F349D2BB5293B48E44FB225C8DD419EC0A5A1319DC10CD916CF4B779CCFCF72C2B2A2DF5AEC339D25652389A7AC59B103390784812B3A20E4DC26056F596D3CC8A7EDD819CDA1F98119120867176E80041763B8544BB1FA6ACD42E95042581A89E9A87AB0CF37A0CBA660EB730CCCE454A3AE80C4E9C9CD859D48351DF4545A6B309C671724624632E455F5B1080D97CE832DCB717D613C4916393292DEF4EB88D4B8A1E188D8BB5CEB8F5E5C030FC250E76147E5F8DE87BD5C776C57A1A4199CDD4F0686237BCA8A4541F8CA9A4891697D251BCFBC2ADA573830147D08916F68757E920DC615995A4D3309C4A52449F519BD0F541F8549E694CA8B3E9A51DC3944A2A8BA28A337487D2DEB3AD2E8D76CAA50E227DE8993ADF4E9F7FEF8696B4D22473665C2596B7B6F9572C3F0F8B7DCDA59E13EE35DF00888EFBC2BBCDD15B939B38F664073CCBC97EDEB7B9C006CB3268F4CFAECCF73A8CA3BD3CA3A4888B34B35037AC548717928CF4F6E4E454C2AC9A592CDBAF8B56BCA7857C0F0CA8451D2D2E24F3E5EE0B1F5689410DB883C920EE8003994CA4C3B31F85F630BC47D145671258BAE561F668CE9B2B6A5B36E701168D3D53BA294B1E6E69C9C21D8DE4CC3C7AB5923314D652FB7027F0A1D9A9D0F435BE37F55A8E3D46225FD9519E429C301131877E3988A0ABFEA96130DE11BC2B2CFAD0AA4786DBDFAE29C7D0174CC31F13E428F4C091F2EFA433012C23CE30D66E617636A14D599DAA0D93467412467DFE54277A3B8CB3AC128F3EACDEAA6F7618A75969423E5D3EE267E773C2B2DCDC7EF88D0B91026FDF199787CD00BCCBFB7E3AD3A0736CEE0507AB1401658646277C7B88BA8002870118F570B5017E3E3705F72892BB318C4A24FE32E6557976B883D20CA4A8F4C7B7D2EF7750FA812C919F015B09B3FA396465515A404A69900CB8976C2D406B18E6167C575D1D824AE7B92F8CAEA94948D33D3A64EC03562924680CC3C007A8580873EA8858489D60A7612032859A3E' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('9BAA33BF9163D479805CD9565513EA81DD5474D79A0299A46910866383FA445C2089F0C336DD2A78449FBBC4718187A19D0AE7DF03170ABFC961E8A1A2D02305AB88E390184614893BC57DB7325254C9F196249D6222FDB19888E65ADAA02A50D409BB15E165A84F8A7AC0B8BA60DA6EE78F59217C493931B8F7092CC3709332C68E66910CE812A6E47D55321E35D16C821B2786D94848F56AE4C1C2C49F024CA9C0F080D4FAA36A268433433675763E94878702621532C502AA6E615500B2B81C6EFF22964AD11DF762E700C11DFA551329B4CCA4325E71E7441B1855B34387A5A469CD4E8FB07E6B4E10D383B938F30E2E3AF3243A70A76A0212D38078932494490D505892632EAC66375000FB225D8D5FF49763918648B0A43D0D00A5ECE4B26DB5F32840D454A93B884009E98389588EC46AE2724758435A7409A277897D5712BF5B63458A4A6623D10ABBC5803573A7D54312690D82506F72B2B49004909276016E082936E94A1E4AB0E7477EE230AA7976C75BF2482387089A518E2436EA3847356ABA1039C42277101714AB12036B118C17FBA1C28E0AFDE84E2E2AC2C31DB5E4115C3C99A31FF2454A0CADA02F5C1231AA924C1E69C5793959A1D208226D022AB94E2BE6C82EF9C44CE88C7AD8EEAFA49CC0AC22438CB5AF58A2186B60D1DA535B104C1E4DC1A19A41F80581A15E00068666733C92D04D2FDEC2E0ABD821611508A0473F6ED8800A4D3A70C002E5E83801B764E3B9B24B955281C7BB4091647DDEBBA8A5AC97BB06BDBB11A53C6E4B29C271DA162140BA6D77A205E9A8ED448E0B9C8B39D4D0714326105138226B9C3774C0B96513A1F3235729D5F387E55D774A3C62F1CFCE5A5A64EAA9D209D6D55E2773BBD3219CD837538A20D73BD31AF9B80E99B8824F9AACAC1351B234454DF591932CCE6E54EB75990ADE1215124CC3578D879CDC5B8D433ACAF0A8269FDC43CDF1B295BE65AA454BA9E3940A5F91EB946DBA8ADCA5E8252DB3DD5AA1B17A612B7D7554B86A2CEF4EB4EC67958B1F576229A7E73462E63682614559D625D4523A8A50501BD37F677A719213B38452383B68BA3BE08BA6B6CE4BA82276707025DC84293D8524915FC11B5DC26348B1370F6A3209EFDC35C82E2155956EB4BE0FAEEBCE264BEF196E40597036414DB237367620C833F02655C525D86EFD709D343DCB92D1720B3C84C1EC8FCBF1E8651384C9F9F8394DB71F269324079D9C6CFCEC1A287A4A4FBC683341E799C9BBB76FDF4F4E4F279B02C6C4232E04E8DBEB7AA414291A6B48D566997257F0931F27E91CA4E01164A96267AB0DD38CB8FD16DC1A55435117DCEC87ABEE90AA0ED9FFE59B017552EA6C85A3A33D0CD14739F988E6751D032F80F4E538EB455002FD84B0DD64CE08F9B30BEC314A080081C85E540131E7AD875914EC36A1D83B' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('42DC9B7099C1C1487D69C4F0F287B0484865913E0CCC65118723F16414C3AA9EECC1015565FA50B21757C322A3340E082B36C02E0E28BCB20283B9342F6C1373698A595867138AFB18671586F92931442F26ADA5866D0176179B70BBD3586792BE6E9658F59820C18265993E94EA21401C4A5566B83C9BA7009965DA5419C2C4B41406A8D0B94009157F3990018B57EAC325DF37C38192358633CDDFFE03F5E3648229735B198EB4D86CA338158D40D4B6C1817ABF908F02D5A8CB3885BB937C189E4B9472944A8A7080375506EB0F6CE8D59797E843681E04C5A134A5263C8CBFF647F2305E6304B17AD48D025715EBC3AA9FAFC321D585FA70EA77EB703875A1C18689E78F21B64C59621909BC3AA108014C986644C6112B7F1D2D77DE2E4E4040F30559A70F35B37BCC236F97ED7E14CB5255A67BD84D94492DDE4E56D598425CA470C38357941BE20C427A4FC38ACD6095CF04D2B0CA627D58CDDB8638A8A6D40412F9EE25098FACD3879AF96A008F9920566CBA2E8ADB51DEDAA86ACC25667DD8E6094EE1495C0CB77AD29590E66599290773E7465519EE5CA86C0313DEAE58D7184A518E0C355A11F5436AC482A84B0DF19B81FC816106BBB2DC10B72AC921CD744CA51127EF567E347D8CD6C5452DC5CC64A5C16A2B9FC825965A59B63787B6DAE46BF7C826B07C6B1CD8843D1D1DD7AA6728599381D1C72EBA2CC235EA478B07B2CA4420164F349272B028338192DD0124306454D1A6DC40984694E6921718F4CF9EE324FAEF9817F4F2DE03D93068971ECB960C32EEA485394301C0CD2229CEF5D5D0BC337F5367AA416009BE59254292FD5B0917CB7ACF012CC9892F867C03C3950F731F40E2DCD4141B6878DBECF0C6E88A75E97046DD394C4110405A472C0B0DB986A7201215067892F98D094CE5A98FC530B1D4B5383C4946DBC1449338ECA28B44E27BCB694822514797DB7467C37EF53C162110446F6689E1CC7D904C03C8E8B578B919B4EC36998555941ACE6BF50D95E4DF993339BCD248A266AF85AF7DA4B4074580152552E9EA5779C151462D595E80B9B9B3C5FAE3F7DBEBE577389F9A8800B2FBC1B1685DF3AF2EEBECE6D35F506F60B1BA547B1D4DAAA2B5D2D00AFDE991D65EB0E2BD6131D657D3B260A1C2B85B88181584C37052B0E96060C3E1E1F7DCE71807F13BC70B5906814E714A1BAE65E94FC5504DF5FEA14433E1BB6D59364B9CD975A4B3B4FB716BB62A3749275827B253E217AD2F3EA5408E127438094A2578646EFFE4F91FC5B00F498ECA3DFFBB8AD26EEB4709E12850AD3002E1C96E970924CEFC1A0C20EDEDE6E3EB5E4FB8BE4E9AFB31F458A72FACB8EF6B247BB7C255DA061C4E55667AB71C85C92EE05F2FD7557BB5D09A4014FB2BAD4E7FD46EA989BBBB596B3720E5DCA55485067E0120F6280E288B4C7C' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('0B5690366B5665FA503E83AFD9E7A1572D566C60C960DC9BA6869E4DA82FED3A5416997ABD5C46290D89A83085377B0688897900AB9A7EE4805B0945A5C725168A3C73EE6012EA8B331FFE2F5D9CF8659D1D298156BCF8EDF9001FE301ECC40358F70EAEBA71153FB676FF7CF4EDF937DBBA5D2DCDFF823B56B6D61432EF8047D6BC169FD58C4ABF65D728EC3902AB30D049728A73215255C34637D88EF931F3E41452CF894F37715926666DAAC1E1C677DC588C5DB1E7AFDF268A60B8304DCF498CA6D7364093DBB19B5E37944DB50AECB76C4BE52735D0B1A18A7A1EC6C5832D735A57B39E4D735CDD691AA40270794DFF7EE2590F665258F110C6C2AA0F332FA2C24485F14142AB2E3E2F519684520148FC27DFE31C4DA82A0398BB60CB5783C81A13C5A07E23835608B08ABD119D4CAE152722B48389540941CCC2CCF32124232B5F1711C33EDA5065B08E36540A9ECBA5CD6428A29BD4A39725F5EF3A4351991D88485B9453214B4294639F94998AE874414593F1283F06ACB25441E5BABF042182B8CADA4D3D0F26C9C92CC862359AA6A885FF847493BBE86F303C1F9F9E9EBC1B8FF23DA1483155A644FA40BFB5A39523E9F4A72C47125C6D267477F34C4B19942459059C3C4BD907AB785E9258E8EC2FF03BFDC92BE6923DB87436A13B9E71D4C6E23D8E70B7798471465EE8E5073244D2B7E351C6C9A836FB2F93ABBF41C420484CAD90AC42E7E83083007354C6A3AB5D1064BE9AE7E3271024ECBB67329D939C03F33CD2225CC197F3F13FF2AE1F468BFF79C07ABF196547B5F8C3E8EDE89F92F91B4EAF746E2926B6029958368480B9D918A357F775835C654E28E7F50D6D19CF2046EBE712BC7C86E13A7D3E1F23F6C5E1E68F5229C0629996E4904D01E7C9976420DFBF7F6F3CD9C6A543BC02B4698C8B60E93A173D78F81A977875F362CAFEF70F45CF87E2AAA459036F468BE43EF4FFBE43CDEED0371EFDF31F3697457533636BBEA7EC7C2D0BA8E6E6872FA87416027DDBD311127EC1D31E1469F2ED38256E42A70E929DCDE1D41518EF2EC806D2646EA68E109B844CED0115E99864A2FCD47CDF696E667557AEC575485E77684A5AF3312A2BB978805FEB01DE9912B0BE177002BDBE2D30268ED63E8EDF00DBFDFE5AC3D737AEFD8F4D679F922E2B53E054162AABB0C9745462B678DF45C7C55254B9599558DE2A29757E6E43FAF2FAC92EE0E68ACC54E5D5834E5E864A157663E858B62B0BFABA682157E90D9C882AC6B1C0F23E58791A38993C952DCBC91864FAACF65AC66584CB2CBB736C6E432C7F3D3CBB5647D4F1845A6E365D3ABD96655A545E1A9D0C14DA67726EEEAAD77922AFEE602D5B7EA85C590C740D935701E2A184C13B398BA7A8857B75B56A19753C1F9765D0798E2EDB30B31B7419CC9F6DAD2A59CEAB57B9B8E894' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('5A1D8C024C1A2D630B3205C18D1D994DCAD5769E35083713C5527D39511E9BFC5F4EC0EFF95D491D24ABD002DAA944A44ADE4627A2D28C991310EF6F4C429D196289CB8C6757F7B530336DE1CE4B23F62A85BACE55590B05B7F6AF371798454F472B19F3CF77727068D2A339034F244B7375FAA113A7B91967982B4A4E8AB2E3D2DEFBAF264A31F62A3F1D9DC1ACA5DAD98776DC5D3976AC1B6349D6BA5B85F5858C2C49D9ABE4D93D57E2F7D85DA9BB2F569167482EE8DBDCD2E019DB8CA9460218F068A6F49ED2DF848499D45EE59276E5473790DEA7487CF62A3FE1512ABF3EA94CA5806B25980918AF4636FF586BFB758967615AB557F9EDF07B2ACB7E3BAE2E41B1B05219E45FDADC313AB9BAD473656801B84ABA64192C95184A7BE7315A62FC40C157B9C6EA8043CBDFA90C41B40DB58C49B40C168B50B40C798ABB06DAF6240B541E766DBC38F0C04627B0AB18C73D110CBD492E2A719CB1464AF4EFF39E4F94C2ED55CA437EBC922DB54314A5E0367AE9186ED43188C0769802AD7D7A41F4D83DC0A773CC90288EC116FAFCFB6ECB572DAE6FAFC974731D3EA0C813BC0D2CA75EDF44C63927235019E89C8C71D34B8C161BB168FB63905ED16D984510A3D1061437415D07788307A175807EE338408F09DC69436036AC480DC524AE9DC907B7174AA225EF0A5E76A3BDC0EF07BB107165BC73686FD4B40B76B138E6D9D42C0377162F5127A63B14732691B3CEB691A8C862679BC8643E3B37362822C19D237D1B4B79D7AB339D2C699C9ED857E68753EF021C10E67799340C470116475332CF94DC4A453F9A8D9D988D458B7F9A2491E7E7EB8756811ECAAC6C546260242F56A3DB28C09B5693CB52CF9D60A597BB20F5B779FCC8F74C54D182E33A9CA3DD2585237432CBBFEF0C241E58B18441B35F896641258FC3A7425791F3F903330C126030CE5447106406F534063E9B6FB096CA0C15A8969A0A71865E0D93AE99C32D0C336D968FACCE88D234C667937A048AE22A5A9C4D30DE91B3546EFF2AFD79C5DC44E4E9C93F5F59D20B179146C462F8B2C809D7889E50B7CE31BC6025C148C2772FFAE1927CA20FF82BE6A57D45CC32BA1FCD11D3606107F81CF06237CCA3FF4D3B728FF4E1770E07A95E411F8A93CAABCD23231D142335312E83F01119C44F456BEF2D2F51A90708D58CAA3A709E92255990F2D5DDD0128ACF597B2EA48E8CA566ACFD925822FF957D3BC20DCD59BD1EE15A30D7F047B8329CE2A19E3C4CF27FF3BC1042EEAA724BE11FB42E23BFE4DB939353E663EE0F8770B364ED0F7F90393EF68543CAE41C47F618983DB0042BC3EC4AB549B17604EB8327CCB6B603E404A35D4BFA586CDF6CC04BA0D342D1DD4B0EE8514D356300E1F3B8BD7C7DD272FDC04F3BD94A0EBCD27B851E25498B5B052C3677181B1F9942E3608E' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('3A74EA0F42C8D175877FD891663A110C39FC6987662E496607CC868B3722ACB844C50FC2656292ED0FA3D1494CF682D7F67F631C9EB97ADC1ADBF0D59EEC8D58BE8343DB1EF1540D1CF622AA5FCD2629CC4F2118756FF6499CD1E48936C8DD52F49599BA1F8AF5A414DC2B06E4A49BD917363C985D747076EB7F2F3565B3A1B7533C31C68338114DF369F136F83725CA8D2C59446E0E1A6453E184418418BB6112711A12D178647A814158A474343F18358B0ABD2D76DDAAECF0152A6EC09A60A8E1B5282A4AE1811F6ED7EAE3C9640A1DE6C10127922C5C69D54ED931F8527698C248B628E3589CB0C805F9267D1DBF40BD1FCF3048F9CC3DD7E03E1E350100022B76F11E3DEA38BF5C2E96B71733C412453CC1F476F6FBE2EBF5723AFFEFFBABBBEB2587ABC8B13179C60C8BD589475C2EAE1617CBBB5B8DB16AB58D19A9AE118F73BFBC9FDE2E7430A2AE9159B4A80612DCAE3F2F668BBBFBF9C5F2EB627977AD1CBBBAFC62C6AC2AC463211A4EE71AE895AEF6EC0845B96480BBE9CD540D1FF7646506C12BC523DDDD4EAF968870D757171AF8D076281633BA8504C72B34F67CBAFCB8B89BCEAE6FA76A6C098B2F8B2F512DC1787173AD3F28EFC420C29A68A446FCFAE3F2E2F6EB34A3BD16EEF239302D141430199D50B19991895AF1A88BAB4FD73717B7CBEB2B0DCE263570EE904DB57CCCAF17BF2F66F79F3596EB179980FDA22561BFD422F672A623CF3D9130F794927CA623C66B0D86E597AA46C22717B7B30B8351241F8C69A11C55FCD9B0FD9DB33736017623AC21BD4B0AC2F044878A1A61A294515AC4D7DC1800BA8A3E6090E869A04E068271B096448A91C6137CBBCAE75A9648102577D1A25359D41D3171EC120F4BCD48A776D327957C66DFCD7BE2C52E90AF32096AE1CE737B3F10D4E51122BC65AD1F526281047CA5B5100E549523528819413F04E2B00981496125118446124BB2BE4F32C83DC639B4307031E79BF2316CEAB2FD2546E51CAD4709AE2BF5C19181E7082CD57D04FEC27610375B48DDD02D45941457AEDF6877D1E71C4D81672707591D1F502BDFB657A556E889C8537FF4DC16AD497C811DA4601EBACE3A294843879A1A32A731A1A71DAEDB11157B4B16C90AD1F206B3B244062101DF25494C070D1726DB4B8563BBC2694254BB200B631DD3228EC26944E67843AD1F0982FB482EF55A52BA85D85C4EBD9243E898C021869E1383D88D01C385289790846719AD0134159DC9C05EBE73F057DCD05B93229419B3585655992D5499AB6231C2F25BE5B653975F24B3FD5B7CED2A63597D0D5AD79D4D0A936C59807EA668935AC33CB15D92979E4D6E9176E76F8A5C6767739825CAAF419C219821F4886BD7BA4DCEDDE5453035A3AA099D500F22251CA4601AA7FE13F05254EDC124F1C3F578F41504BB4C3A6C1EE16A' as long raw)));
dbms_lob.append(model_blob, to_blob(cast('115EEFD2ED2E4528C3CD63F01D2746768B2C1BFF6CC2CCF9EC7A9BFD4A6CA080A6E96789F3AFC38F3B3F58D5F3FEC449232900915D4F979978B36F593C12FEBD867415859A804AF2D5B7EA7770B30D10B0E43A5C826FB0CDDCEE13F819AE81F73D4F55BDCA920A8A80A83F0449F6B3B90FD631D824258CA63FFA897878B579F9D3FF03B7864978459E0100' as long raw)));
insert into "ADMSISREC"."__MigrationHistory"("MigrationId", "ContextKey", "Model", "ProductVersion")
values ('202011130457261_MigQSiniestros', 'Recuperos.Persistencia.BaseOracle.Migrations.Configuration', model_blob, '6.4.0');
end;
