æG
NG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\App_Start\Startup.Auth.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
{ 
public 

partial 
class 
Startup  
{ 
	protected 
void 
ConfigIdentity %
(% &
IServiceCollection& 8
services9 A
,A B
IConfigurationC Q
ConfigurationR _
,_ `
stringa g
connectionNameh v
)v w
{ 	
services 
. 
AddDbContext !
<! " 
ApplicationDbContext" 6
>6 7
(7 8
)8 9
;9 :
PasswordOptions 
pOpt  
=! "
new# &
PasswordOptions' 6
(6 7
)7 8
{ 
RequireDigit 
= 
false $
,$ %
RequiredLength 
=  
$num! "
," #
RequireLowercase    
=  ! "
false  # (
,  ( )"
RequireNonAlphanumeric!! &
=!!' (
false!!) .
,!!. /
RequireUppercase""  
=""! "
false""# (
}## 
;## 
services%% 
.%% 
AddIdentity%%  
<%%  !
ApplicationUser%%! 0
,%%0 1
IdentityRole%%2 >
>%%> ?
(%%? @
options%%@ G
=>%%H J
{&& 
options'' 
.'' 
Password''  
=''! "
pOpt''# '
;''' (
}(( 
)(( 
.)) $
AddEntityFrameworkStores)) )
<))) * 
ApplicationDbContext))* >
>))> ?
())? @
)))@ A
.** $
AddDefaultTokenProviders** )
(**) *
)*** +
.++ 
AddUserManager++ 
<++  
UserManager++  +
<+++ ,
ApplicationUser++, ;
>++; <
>++< =
(++= >
)++> ?
;,, 
services-- 
.-- 
AddAuthorization-- %
(--% &
options--& -
=>--. 0
{.. 
options// 
.// 
	AddPolicy// !
(//! "
$str//" /
,/// 0
policy//1 7
=>//8 :
{00 
policy11 
.11 
RequireClaim11 '
(11' (
$str11( 2
)112 3
;113 4
policy22 
.22 
RequireClaim22 '
(22' (
$str22( 3
)223 4
;224 5
}33 
)33 
;33 
options44 
.44 
	AddPolicy44 !
(44! "
$str44" .
,44. /
policy440 6
=>447 9
policy44: @
.44@ A
RequireClaim44A M
(44M N
$str44N [
)44[ \
)44\ ]
;44] ^
}55 
)55 
;66 
}77 	
	protected99 
void99 
ConfigJWTToken99 %
(99% &
IServiceCollection99& 8
services999 A
,99A B
IConfiguration99C Q
Configuration99R _
)99_ `
{:: 	
services;; 
.;; 
AddAuthentication;; &
(;;& '
JwtBearerDefaults;;' 8
.;;8 9 
AuthenticationScheme;;9 M
);;M N
.<< 
AddJwtBearer<< !
(<<! "
options<<" )
=><<* ,
{== 
options>> 
.>>  %
TokenValidationParameters>>  9
=>>: ;
new??  %
TokenValidationParameters??! :
{@@ 
ValidateIssuerAA! /
=AA0 1
falseAA2 7
,AA7 8
ValidateAudienceBB! 1
=BB2 3
falseBB4 9
,BB9 :
ValidateLifetimeCC! 1
=CC2 3
trueCC4 8
,CC8 9$
ValidateIssuerSigningKeyDD! 9
=DD: ;
trueDD< @
,DD@ A
ValidIssuerFF! ,
=FF- .
SWCmsConstantsFF/ =
.FF= >
JwtSettingsFF> I
.FFI J
ISSUERFFJ P
,FFP Q
ValidAudienceGG! .
=GG/ 0
SWCmsConstantsGG1 ?
.GG? @
JwtSettingsGG@ K
.GGK L
AUDIENCEGGL T
,GGT U
IssuerSigningKeyHH! 1
=HH2 3
JwtSecurityKeyHH4 B
.HHB C
CreateHHC I
(HHI J
SWCmsConstantsHHJ X
.HHX Y
JwtSettingsHHY d
.HHd e

SECRET_KEYHHe o
)HHo p
}II 
;II 
optionsJJ 
.JJ  
EventsJJ  &
=JJ' (
newJJ) ,
JwtBearerEventsJJ- <
{KK "
OnAuthenticationFailedLL 2
=LL3 4
contextLL5 <
=>LL= ?
{MM 
ConsoleNN  '
.NN' (
	WriteLineNN( 1
(NN1 2
$strNN2 L
+NNM N
contextNNO V
.NNV W
	ExceptionNNW `
.NN` a
MessageNNa h
)NNh i
;NNi j
returnOO  &
TaskOO' +
.OO+ ,
CompletedTaskOO, 9
;OO9 :
}PP 
,PP 
OnTokenValidatedQQ ,
=QQ- .
contextQQ/ 6
=>QQ7 9
{RR 
ConsoleSS  '
.SS' (
	WriteLineSS( 1
(SS1 2
$strSS2 F
+SSG H
contextSSI P
.SSP Q
SecurityTokenSSQ ^
)SS^ _
;SS_ `
returnTT  &
TaskTT' +
.TT+ ,
CompletedTaskTT, 9
;TT9 :
}UU 
}VV 
;VV 
}WW 
)WW 
;WW 
}XX 	
	protectedZZ 
voidZZ 
ConfigCookieAuthZZ '
(ZZ' (
IServiceCollectionZZ( :
servicesZZ; C
,ZZC D
IConfigurationZZE S
ConfigurationZZT a
)ZZa b
{[[ 	
services\\ 
.\\ &
ConfigureApplicationCookie\\ /
(\\/ 0
options\\0 7
=>\\8 :
{]] 
options__ 
.__ 
Cookie__ 
.__ 
HttpOnly__ '
=__( )
true__* .
;__. /
options`` 
.`` 
Cookie`` 
.`` 

Expiration`` )
=``* +
TimeSpan``, 4
.``4 5
FromDays``5 =
(``= >
$num``> A
)``A B
;``B C
optionsaa 
.aa 
	LoginPathaa !
=aa" #
$straa$ '
+aa( )'
CONST_ROUTE_DEFAULT_CULTUREaa* E
+aaF G
$straaH \
;aa\ ]
optionsbb 
.bb 

LogoutPathbb "
=bb# $
$strbb% (
+bb) *'
CONST_ROUTE_DEFAULT_CULTUREbb+ F
+bbG H
$strbbI ^
;bb^ _
optionscc 
.cc 
AccessDeniedPathcc (
=cc) *
$strcc+ .
;cc. /
optionsdd 
.dd 
SlidingExpirationdd )
=dd* +
truedd, 0
;dd0 1
}ee 
)ee 
;ee 
servicesgg 
.gg 
AddAuthenticationgg &
(gg& '(
CookieAuthenticationDefaultsgg' C
.ggC D 
AuthenticationSchemeggD X
)ggX Y
.hh 
	AddCookiehh 
(hh 
optionsii 
=>ii 
{jj 
optionsll 
.ll 
Cookiell "
.ll" #
HttpOnlyll# +
=ll, -
truell. 2
;ll2 3
optionsmm 
.mm 
Cookiemm "
.mm" #

Expirationmm# -
=mm. /
TimeSpanmm0 8
.mm8 9
FromDaysmm9 A
(mmA B
$nummmB E
)mmE F
;mmF G
optionsnn 
.nn 
	LoginPathnn %
=nn& '
$strnn( +
+nn, -'
CONST_ROUTE_DEFAULT_CULTUREnn. I
+nnJ K
$strnnL `
;nn` a
optionsoo 
.oo 

LogoutPathoo &
=oo' (
$stroo) ,
+oo- .'
CONST_ROUTE_DEFAULT_CULTUREoo/ J
+ooK L
$strooM b
;oob c
optionspp 
.pp 
AccessDeniedPathpp ,
=pp- .
$strpp/ 2
;pp2 3
optionsqq 
.qq 
SlidingExpirationqq -
=qq. /
trueqq0 4
;qq4 5
}rr 
)rr 
;rr 
}ss 	
	protecteduu 
staticuu 
classuu 
JwtSecurityKeyuu -
{vv 	
publicww 
staticww  
SymmetricSecurityKeyww .
Createww/ 5
(ww5 6
stringww6 <
secretww= C
)wwC D
{xx 
returnyy 
newyy  
SymmetricSecurityKeyyy /
(yy/ 0
Encodingyy0 8
.yy8 9
ASCIIyy9 >
.yy> ?
GetBytesyy? G
(yyG H
secretyyH N
)yyN O
)yyO P
;yyP Q
}zz 
}{{ 	
}|| 
}}} ‡ç
aG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Areas\Portal\Controllers\PortalController.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Mvc 
. 
Areas  
.  !
Portal! '
.' (
Controllers( 3
{ 
[ 
Area 	
(	 

$str
 
) 
] 
[ 
Route 

(
 
$str 
) 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
PortalController !
:" #
BaseController$ 2
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_roleManager3 ?
;? @
public 
PortalController 
(  
IHostingEnvironment  3
env4 7
,7 8
IConfiguration9 G
configurationH U
,U V
UserManager   
<   
ApplicationUser   '
>  ' (
userManager  ) 4
,  4 5
RoleManager!! 
<!! 
IdentityRole!! $
>!!$ %
roleManager!!& 1
)"" 
:## 
base## 
(## 
env## 
,## 
configuration## %
)##% &
{$$ 	
this%% 
.%% 
_userManager%% 
=%% 
userManager%%  +
;%%+ ,
this&& 
.&& 
_roleManager&& 
=&& 
roleManager&&  +
;&&+ ,
}'' 	
[)) 	
HttpGet))	 
])) 
[** 	
Route**	 
(** 
$str** 
)** 
]** 
public++ 
IActionResult++ 
Index++ "
(++" #
)++# $
{,, 	
return-- 
RedirectToAction-- #
(--# $
$str--$ &
,--& '
$str--( 3
,--3 4
new--5 8
{--9 :
culture--; B
=--C D
CurrentLanguage--E T
}--U V
)--V W
;--W X
}.. 	
[00 	
HttpGet00	 
]00 
[11 	
Route11	 
(11 
$str11 
)11 
]11 
[22 	
Route22	 
(22 
$str22 
)22 
]22 
public33 
IActionResult33 
Init33 !
(33! "
)33" #
{44 	
return55 
View55 
(55 
)55 
;55 
}66 	
[88 	
HttpPost88	 
]88 
[99 	
Route99	 
(99 
$str99 
)99 
]99 
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
Init::) -
(::- .
InitCmsViewModel::. >
model::? D
)::D E
{;; 	
if<< 
(<< 

ModelState<< 
.<< 
IsValid<< "
)<<" #
{== 
string>> 
	cnnString>>  
=>>! "
string>># )
.>>) *
Empty>>* /
;>>/ 0
if?? 
(?? 
!?? 
model?? 
.?? 

IsUseLocal?? %
)??% &
{@@ 
	cnnStringAA 
=AA 
stringAA  &
.AA& '
FormatAA' -
(AA- .
$strAA. v
,BB 
modelBB 
.BB 
DataBaseServerBB -
,BB- .
modelBB/ 4
.BB4 5
DataBaseNameBB5 A
,BBA B
modelBBC H
.BBH I
DataBaseUserBBI U
,BBU V
modelBBW \
.BB\ ]
DataBasePasswordBB] m
)BBm n
;BBn o
}CC 
elseDD 
{EE 
	cnnStringFF 
=FF 
modelFF  %
.FF% &#
LocalDbConnectionStringFF& =
;FF= >
}GG 
varHH 
settingsHH 
=HH 
FileRepositoryHH -
.HH- .
InstanceHH. 6
.HH6 7
GetFileHH7 >
(HH> ?
$strHH? L
,HHL M
$strHHN U
,HHU V
stringHHW ]
.HH] ^
EmptyHH^ c
,HHc d
trueHHe i
,HHi j
$strHHk o
)HHo p
;HHp q
ifII 
(II 
settingsII 
!=II 
nullII  $
)II$ %
{JJ 
JObjectKK 
jsonSettingsKK (
=KK) *
JObjectKK+ 2
.KK2 3
ParseKK3 8
(KK8 9
settingsKK9 A
.KKA B
ContentKKB I
)KKI J
;KKJ K
jsonSettingsLL  
[LL  !
$strLL! 4
]LL4 5
[LL5 6
SWCmsConstantsLL6 D
.LLD E$
CONST_DEFAULT_CONNECTIONLLE ]
]LL] ^
=LL_ `
	cnnStringLLa j
;LLj k
jsonSettingsNN  
[NN  !
$strNN! 4
]NN4 5
[NN5 6
$strNN6 I
]NNI J
=NNK L
	cnnStringNNM V
;NNV W
settingsOO 
.OO 
ContentOO $
=OO% &
jsonSettingsOO' 3
.OO3 4
ToStringOO4 <
(OO< =
)OO= >
;OO> ?
FileRepositoryPP "
.PP" #
InstancePP# +
.PP+ ,
SaveFilePP, 4
(PP4 5
settingsPP5 =
)PP= >
;PP> ?
}QQ 
varRR 

initResultRR 
=RR  
awaitRR! &&
GlobalConfigurationServiceRR' A
.RRA B
InstanceRRB J
.RRJ K
	InitSWCmsRRK T
(RRT U
_userManagerRRU a
,RRa b
_roleManagerRRc o
)RRo p
;RRp q
ifSS 
(SS 

initResultSS 
.SS 
	IsSucceedSS (
)SS( )
{TT 
awaitWW 
InitRolesAsyncWW (
(WW( )
)WW) *
;WW* +
returnXX 
RedirectToActionXX +
(XX+ ,
$strXX, @
,XX@ A
$strXXB H
,XXH I
newXXJ M
{XXN O
cultureXXP W
=XXX Y&
GlobalConfigurationServiceXXZ t
.XXt u
InstanceXXu }
.XX} ~
CmsConfigurations	XX~ è
.
XXè ê
Language
XXê ò
}
XXô ö
)
XXö õ
;
XXõ ú
}YY 
elseZZ 
{[[ 
settings\\ 
=\\ 
FileRepository\\ -
.\\- .
Instance\\. 6
.\\6 7
GetFile\\7 >
(\\> ?
$str\\? L
,\\L M
$str\\N U
,\\U V
string\\W ]
.\\] ^
Empty\\^ c
)\\c d
;\\d e
JObject]] 
jsonSettings]] (
=]]) *
JObject]]+ 2
.]]2 3
Parse]]3 8
(]]8 9
settings]]9 A
.]]A B
Content]]B I
)]]I J
;]]J K
jsonSettings^^  
[^^  !
$str^^! 4
]^^4 5
[^^5 6
SWCmsConstants^^6 D
.^^D E$
CONST_DEFAULT_CONNECTION^^E ]
]^^] ^
=^^_ `
null^^a e
;^^e f
jsonSettings__  
[__  !
$str__! 4
]__4 5
[__5 6
$str__6 I
]__I J
=__K L
null__M Q
;__Q R
settingsaa 
.aa 
Contentaa $
=aa% &
jsonSettingsaa' 3
.aa3 4
ToStringaa4 <
(aa< =
)aa= >
;aa> ?
FileRepositorybb "
.bb" #
Instancebb# +
.bb+ ,
SaveFilebb, 4
(bb4 5
settingsbb5 =
)bb= >
;bb> ?
ifcc 
(cc 

initResultcc "
.cc" #
	Exceptioncc# ,
!=cc- /
nullcc0 4
)cc4 5
{dd 

ModelStateee "
.ee" #
AddModelErroree# 0
(ee0 1
$stree1 3
,ee3 4

initResultee5 ?
.ee? @
	Exceptionee@ I
.eeI J
MessageeeJ Q
)eeQ R
;eeR S
}ff 
foreachgg 
(gg 
vargg  
itemgg! %
ingg& (

initResultgg) 3
.gg3 4
Errorsgg4 :
)gg: ;
{hh 

ModelStateii "
.ii" #
AddModelErrorii# 0
(ii0 1
$strii1 3
,ii3 4
itemii5 9
)ii9 :
;ii: ;
}jj 
}kk 
}ll 
returnmm 
Viewmm 
(mm 
modelmm 
)mm 
;mm 
}nn 	
privatepp 
asyncpp 
Taskpp 
<pp 
boolpp 
>pp  
InitRolesAsyncpp! /
(pp/ 0
)pp0 1
{qq 	
boolrr 
	isSucceedrr 
=rr 
truerr !
;rr! "
varss 
getRolesss 
=ss 
awaitss  
RoleViewModelss! .
.ss. /

Repositoryss/ 9
.ss9 :
GetModelListAsyncss: K
(ssK L
)ssL M
;ssM N
iftt 
(tt 
getRolestt 
.tt 
	IsSucceedtt "
&&tt# %
getRolestt& .
.tt. /
Datatt/ 3
.tt3 4
Counttt4 9
==tt: <
$numtt= >
)tt> ?
{uu 
varvv 

saveResultvv 
=vv  
awaitvv! &
_roleManagervv' 3
.vv3 4
CreateAsyncvv4 ?
(vv? @
newvv@ C
IdentityRolevvD P
(vvP Q
)vvQ R
{ww 
Idxx 
=xx 
Guidxx 
.xx 
NewGuidxx %
(xx% &
)xx& '
.xx' (
ToStringxx( 0
(xx0 1
)xx1 2
,xx2 3
Nameyy 
=yy 
$stryy '
}zz 
)zz 
;zz 
	isSucceed{{ 
={{ 

saveResult{{ &
.{{& '
	Succeeded{{' 0
;{{0 1
}|| 
return}} 
	isSucceed}} 
;}} 
}~~ 	
[
ÜÜ 	
HttpGet
ÜÜ	 
,
ÜÜ 
HttpPost
ÜÜ 
]
ÜÜ 
[
áá 	
Route
áá	 
(
áá 
$str
áá 
)
áá 
]
áá 
public
àà 
async
àà 
Task
àà 
<
àà 
IActionResult
àà '
>
àà' (
Search
àà) /
(
àà/ 0
string
àà0 6
keyword
àà7 >
,
àà> ?
SWCmsConstants
àà@ N
.
ààN O

SearchType
ààO Y

searchType
ààZ d
)
ààd e
{
ââ 	
switch
ää 
(
ää 

searchType
ää 
)
ää 
{
ãã 
case
åå 
SWCmsConstants
åå #
.
åå# $

SearchType
åå$ .
.
åå. /
All
åå/ 2
:
åå2 3
ViewData
çç 
[
çç 
$str
çç '
]
çç' (
=
çç) *
(
çç+ ,
await
çç, 1"
InfoArticleViewModel
çç2 F
.
ççF G

Repository
ççG Q
.
ççQ R!
GetModelListByAsync
ççR e
(
ççe f
c
éé 
=>
éé 
c
éé 
.
éé 
Specificulture
éé -
==
éé. 0
CurrentLanguage
éé1 @
&&
ééA C
(
ééD E
c
ééE F
.
ééF G
Title
ééG L
.
ééL M
Contains
ééM U
(
ééU V
keyword
ééV ]
)
éé] ^
||
éé_ a
c
ééb c
.
ééc d
Excerpt
ééd k
.
éék l
Contains
éél t
(
éét u
keyword
ééu |
)
éé| }
||éé~ Ä
cééÅ Ç
.ééÇ É
ContentééÉ ä
.ééä ã
Containsééã ì
(ééì î
keywordééî õ
)ééõ ú
)ééú ù
)ééù û
.ééû ü
ConfigureAwaitééü ≠
(éé≠ Æ
falseééÆ ≥
)éé≥ ¥
)
èè 
.
èè 
Data
èè 
;
èè 
ViewData
êê 
[
êê 
$str
êê $
]
êê$ %
=
êê& '
(
êê( )#
InfoCategoryViewModel
êê) >
.
êê> ?

Repository
êê? I
.
êêI J
GetModelListBy
êêJ X
(
êêX Y
c
ëë 
=>
ëë 
c
ëë 
.
ëë 
Specificulture
ëë -
==
ëë. 0
CurrentLanguage
ëë1 @
&&
íí 
(
íí 
c
íí 
.
íí 
Title
íí #
.
íí# $
Contains
íí$ ,
(
íí, -
keyword
íí- 4
)
íí4 5
||
íí6 8
c
íí9 :
.
íí: ;
Excerpt
íí; B
.
ííB C
Contains
ííC K
(
ííK L
keyword
ííL S
)
ííS T
)
ííT U
)
ííU V
)
ìì 
.
ìì 
Data
ìì 
;
ìì 
ViewData
îî 
[
îî 
$str
îî &
]
îî& '
=
îî( )
(
îî* +!
InfoModuleViewModel
îî+ >
.
îî> ?

Repository
îî? I
.
îîI J
GetModelListBy
îîJ X
(
îîX Y
c
ïï 
=>
ïï 
c
ïï 
.
ïï 
Specificulture
ïï -
==
ïï. 0
CurrentLanguage
ïï1 @
&&
ïïA C
(
ïïD E
c
ïïE F
.
ïïF G
Title
ïïG L
.
ïïL M
Contains
ïïM U
(
ïïU V
keyword
ïïV ]
)
ïï] ^
||
ññ 
c
ññ 
.
ññ 
Description
ññ (
.
ññ( )
Contains
ññ) 1
(
ññ1 2
keyword
ññ2 9
)
ññ9 :
)
ññ: ;
)
ññ; <
)
óó 
.
óó 
Data
óó 
;
óó 
break
òò 
;
òò 
case
öö 
SWCmsConstants
öö #
.
öö# $

SearchType
öö$ .
.
öö. /
Article
öö/ 6
:
öö6 7
ViewData
õõ 
[
õõ 
$str
õõ '
]
õõ' (
=
õõ) *
(
õõ+ ,
await
õõ, 1"
InfoArticleViewModel
õõ2 F
.
õõF G

Repository
õõG Q
.
õõQ R!
GetModelListByAsync
õõR e
(
õõe f
c
úú 
=>
úú 
c
úú 
.
úú 
Specificulture
úú -
==
úú. 0
CurrentLanguage
úú1 @
&&
úúA C
(
úúD E
c
úúE F
.
úúF G
Title
úúG L
.
úúL M
Contains
úúM U
(
úúU V
keyword
úúV ]
)
úú] ^
||
úú_ a
c
úúb c
.
úúc d
Excerpt
úúd k
.
úúk l
Contains
úúl t
(
úút u
keyword
úúu |
)
úú| }
||úú~ Ä
cúúÅ Ç
.úúÇ É
ContentúúÉ ä
.úúä ã
Containsúúã ì
(úúì î
keywordúúî õ
)úúõ ú
)úúú ù
)úúù û
.úúû ü
ConfigureAwaitúúü ≠
(úú≠ Æ
falseúúÆ ≥
)úú≥ ¥
)
ùù 
.
ùù 
Data
ùù 
;
ùù 
break
ûû 
;
ûû 
case
†† 
SWCmsConstants
†† #
.
††# $

SearchType
††$ .
.
††. /
Module
††/ 5
:
††5 6
ViewData
°° 
[
°° 
$str
°° &
]
°°& '
=
°°( )
(
°°* +!
InfoModuleViewModel
°°+ >
.
°°> ?

Repository
°°? I
.
°°I J
GetModelListBy
°°J X
(
°°X Y
c
¢¢ 
=>
¢¢ 
c
¢¢ 
.
¢¢ 
Specificulture
¢¢ -
==
¢¢. 0
CurrentLanguage
¢¢1 @
&&
¢¢A C
(
¢¢D E
c
¢¢E F
.
¢¢F G
Title
¢¢G L
.
¢¢L M
Contains
¢¢M U
(
¢¢U V
keyword
¢¢V ]
)
¢¢] ^
||
¢¢_ a
c
¢¢b c
.
¢¢c d
Description
¢¢d o
.
¢¢o p
Contains
¢¢p x
(
¢¢x y
keyword¢¢y Ä
)¢¢Ä Å
)¢¢Å Ç
)¢¢Ç É
)
££ 
.
££ 
Data
££ 
;
££ 
break
§§ 
;
§§ 
case
¶¶ 
SWCmsConstants
¶¶ #
.
¶¶# $

SearchType
¶¶$ .
.
¶¶. /
Page
¶¶/ 3
:
¶¶3 4
ViewData
ßß 
[
ßß 
$str
ßß $
]
ßß$ %
=
ßß& '
(
ßß( )#
InfoCategoryViewModel
ßß) >
.
ßß> ?

Repository
ßß? I
.
ßßI J
GetModelListBy
ßßJ X
(
ßßX Y
c
®® 
=>
®® 
c
®® 
.
®® 
Specificulture
®® -
==
®®. 0
CurrentLanguage
®®1 @
&&
©© 
(
©© 
c
©© 
.
©© 
Title
©© #
.
©©# $
Contains
©©$ ,
(
©©, -
keyword
©©- 4
)
©©4 5
||
©©6 8
c
©©9 :
.
©©: ;
Excerpt
©©; B
.
©©B C
Contains
©©C K
(
©©K L
keyword
©©L S
)
©©S T
)
©©T U
)
©©U V
)
™™ 
.
™™ 
Data
™™ 
;
™™ 
break
´´ 
;
´´ 
default
≠≠ 
:
≠≠ 
break
ÆÆ 
;
ÆÆ 
}
ØØ 
ViewBag
∞∞ 
.
∞∞ 

searchType
∞∞ 
=
∞∞  

searchType
∞∞! +
;
∞∞+ ,
return
±± 
View
±± 
(
±± 
)
±± 
;
±± 
}
≤≤ 	
}
≥≥ 
}¥¥ Ô
UG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Controllers\BackendController.cs
	namespace

 	
Swastika


 
.

 
Cms

 
.

 
Mvc

 
.

 
Controllers

 &
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
BackendController "
:# $
BaseController% 3
{ 
public 
BackendController  
(  !
IHostingEnvironment! 4
env5 8
)8 9
:: ;
base< @
(@ A
envA D
)D E
{ 	
}	 

[ 	
Route	 
( 
$str 
) 
] 
[ 	
Route	 
( 
$str 
) 
] 
[ 	
Route	 
( 
$str "
)" #
]# $
[ 	
Route	 
( 
$str *
)* +
]+ ,
[ 	
Route	 
( 
$str 3
)3 4
]4 5
[ 	
Route	 
( 
$str <
)< =
]= >
[ 	
Route	 
( 
$str E
)E F
]F G
[ 	
Route	 
( 
$str N
)N O
]O P
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
Route	 
( 
$str 
) 
] 
public   
IActionResult   
Init   !
(  ! "
)  " #
{!! 	
return"" 
View"" 
("" 
)"" 
;"" 
}## 	
}$$ 
}%% ƒ@
RG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Controllers\BaseController.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Mvc 
. 
Controllers &
{ 
public 

class 
BaseController 
:  !

Controller" ,
{ 
public 
readonly 
string 
ROUTE_CULTURE_NAME 1
=2 3
$str4 =
;= >
public 
readonly 
string !
ROUTE_DEFAULT_CULTURE 4
=5 6&
GlobalConfigurationService7 Q
.Q R
InstanceR Z
.Z [
CmsConfigurations[ l
?l m
.m n
Languagen v
??w y
$str	z Å
;
Å Ç
	protected 
string 
_domain  
;  !
	protected 
IConfiguration  
_configuration! /
;/ 0
	protected 
IHostingEnvironment %
_env& *
;* +
private 
string 
_currentLanguage '
;' (
public 
BaseController 
( 
IHostingEnvironment 1
env2 5
)5 6
{ 	
_env 
= 
env 
; 
var!! 
cultureInfo!! 
=!! 
new!! !
CultureInfo!!" -
(!!- .
CurrentLanguage!!. =
)!!= >
;!!> ?
CultureInfo"" 
."" '
DefaultThreadCurrentCulture"" 3
=""4 5
cultureInfo""6 A
;""A B
CultureInfo## 
.## )
DefaultThreadCurrentUICulture## 5
=##6 7
cultureInfo##8 C
;##C D
}$$ 	
public&& 
BaseController&& 
(&& 
IHostingEnvironment&& 1
env&&2 5
,&&5 6
IConfiguration&&7 E
configuration&&F S
)&&S T
{'' 	
_configuration(( 
=(( 
configuration(( *
;((* +
_env)) 
=)) 
env)) 
;)) 
var++ 
cultureInfo++ 
=++ 
new++ !
CultureInfo++" -
(++- .
CurrentLanguage++. =
)++= >
;++> ?
CultureInfo,, 
.,, '
DefaultThreadCurrentCulture,, 3
=,,4 5
cultureInfo,,6 A
;,,A B
CultureInfo-- 
.-- )
DefaultThreadCurrentUICulture-- 5
=--6 7
cultureInfo--8 C
;--C D
}.. 	
public00 
ViewContext00 
ViewContext00 &
{00' (
get00) ,
;00, -
set00. 1
;001 2
}003 4
	protected22 
string22 
CurrentLanguage22 (
{33 	
get44 
{55 
_currentLanguage66  
=66! "
	RouteData66# ,
?66, -
.66- .
Values66. 4
[664 5
ROUTE_CULTURE_NAME665 G
]66G H
!=66I K
null66L P
?77$ %
	RouteData77& /
.77/ 0
Values770 6
[776 7
ROUTE_CULTURE_NAME777 I
]77I J
.77J K
ToString77K S
(77S T
)77T U
.77U V
ToLower77V ]
(77] ^
)77^ _
:77` a!
ROUTE_DEFAULT_CULTURE77b w
.77w x
ToLower77x 
(	77 Ä
)
77Ä Å
;
77Å Ç
return88 
_currentLanguage88 '
;88' (
}99 
}:: 	
public<< 
override<< 
void<< 
OnActionExecuting<< .
(<<. /"
ActionExecutingContext<</ E
context<<F M
)<<M N
{== 	
if>> 
(>> 
!>> 
string>> 
.>> 
IsNullOrEmpty>> %
(>>% &&
GlobalConfigurationService>>& @
.>>@ A
Instance>>A I
.>>I J
CmsConfigurations>>J [
.>>[ \
CmsConnectionString>>\ o
)>>o p
)>>p q
{?? 
GetLanguage@@ 
(@@ 
)@@ 
;@@ 
}AA 
baseBB 
.BB 
OnActionExecutingBB "
(BB" #
contextBB# *
)BB* +
;BB+ ,
}CC 	
	protectedEE 
voidEE 
GetLanguageEE "
(EE" #
)EE# $
{FF 	
_domainGG 
=GG 
stringGG 
.GG 
FormatGG #
(GG# $
$strGG$ /
,GG/ 0
RequestGG1 8
.GG8 9
SchemeGG9 ?
,GG? @
RequestGGA H
.GGH I
HostGGI M
)GGM N
;GGN O
ViewBagII 
.II 
cultureII 
=II 
CurrentLanguageII -
;II- .
}JJ 	
	protectedLL 
asyncLL 
TaskLL 
<LL 
stringLL #
>LL# $
UploadFileAsyncLL% 4
(LL4 5
	IFormFileLL5 >
fileLL? C
,LLC D
stringLLE K

folderPathLLL V
)LLV W
{MM 	
ifNN 
(NN 
fileNN 
!=NN 
nullNN 
&&NN 
fileNN  $
.NN$ %
LengthNN% +
>NN, -
$numNN. /
)NN/ 0
{OO 
stringPP 
fileNamePP 
=PP  !
awaitPP" '
CommonHelperPP( 4
.PP4 5
UploadFileAsyncPP5 D
(PPD E
SystemPPE K
.PPK L
IOPPL N
.PPN O
PathPPO S
.PPS T
CombinePPT [
(PP[ \
_envPP\ `
.PP` a
WebRootPathPPa l
,PPl m

folderPathPPn x
)PPx y
,PPy z
filePP{ 
)	PP Ä
;
PPÄ Å
ifQQ 
(QQ 
!QQ 
stringQQ 
.QQ 
IsNullOrEmptyQQ )
(QQ) *
fileNameQQ* 2
)QQ2 3
)QQ3 4
{RR 
stringSS 
filePathSS #
=SS$ %
stringSS& ,
.SS, -
FormatSS- 3
(SS3 4
$strSS4 =
,SS= >

folderPathSS? I
,SSI J
fileNameSSK S
)SSS T
;SST U
returnTT 
filePathTT #
;TT# $
}UU 
elseVV 
{WW 
returnXX 
stringXX !
.XX! "
EmptyXX" '
;XX' (
}YY 
}ZZ 
else[[ 
{\\ 
return]] 
string]] 
.]] 
Empty]] #
;]]# $
}^^ 
}__ 	
	protectedaa 
asyncaa 
Taskaa 
<aa 
Listaa !
<aa! "
stringaa" (
>aa( )
>aa) *
UploadListFileAsyncaa+ >
(aa> ?
stringaa? E

folderPathaaF P
)aaP Q
{bb 	
Listcc 
<cc 
stringcc 
>cc 
resultcc 
=cc  !
newcc" %
Listcc& *
<cc* +
stringcc+ 1
>cc1 2
(cc2 3
)cc3 4
;cc4 5
vardd 
filesdd 
=dd 
HttpContextdd #
.dd# $
Requestdd$ +
.dd+ ,
Formdd, 0
.dd0 1
Filesdd1 6
;dd6 7
foreachee 
(ee 
varee 
fileee 
inee  
filesee! &
)ee& '
{ff 
stringgg 
fileNamegg 
=gg  !
awaitgg" '
UploadFileAsyncgg( 7
(gg7 8
filegg8 <
,gg< =

folderPathgg> H
)ggH I
;ggI J
ifhh 
(hh 
!hh 
stringhh 
.hh 
IsNullOrEmptyhh )
(hh) *
fileNamehh* 2
)hh2 3
)hh3 4
{ii 
resultjj 
.jj 
Addjj 
(jj 
fileNamejj '
)jj' (
;jj( )
}kk 
}ll 
returnmm 
resultmm 
;mm 
}nn 	
}oo 
}pp ƒ‡
RG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Controllers\HomeController.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Mvc 
. 
Controllers &
{ 
[ 
ResponseCache 
( 
CacheProfileName #
=$ %
$str& /
)/ 0
]0 1
[ 
Route 

(
 
$str 
) 
] 
public 

class 
HomeController 
:  !
BaseController" 0
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly 
RoleManager $
<$ %
IdentityRole% 1
>1 2
_roleManager3 ?
;? @
public 
HomeController 
( 
IHostingEnvironment 1
env2 5
,5 6
UserManager 
< 
ApplicationUser (
>( )
userManager* 5
,5 6
RoleManager   
<   
IdentityRole   $
>  $ %
roleManager  & 1
)!! 
:"" 
base"" 
("" 
env"" 
)"" 
{## 	
this$$ 
.$$ 
_userManager$$ 
=$$ 
userManager$$  +
;$$+ ,
this%% 
.%% 
_roleManager%% 
=%% 
roleManager%%  +
;%%+ ,
}&& 	
[(( 	
HttpPost((	 
](( 
public)) 
IActionResult)) 
SetLanguage)) (
())( )
string))) /
culture))0 7
,))7 8
string))9 ?
	returnUrl))@ I
)))I J
{** 	
Response++ 
.++ 
Cookies++ 
.++ 
Append++ #
(++# $(
CookieRequestCultureProvider,, ,
.,,, -
DefaultCookieName,,- >
,,,> ?(
CookieRequestCultureProvider-- ,
.--, -
MakeCookieValue--- <
(--< =
new--= @
RequestCulture--A O
(--O P
culture--P W
)--W X
)--X Y
,--Y Z
new.. 
CookieOptions.. !
{.." #
Expires..$ +
=.., -
DateTimeOffset... <
...< =
UtcNow..= C
...C D
AddYears..D L
(..L M
$num..M N
)..N O
}..P Q
)// 
;// 
return11 
LocalRedirect11  
(11  !
	returnUrl11! *
)11* +
;11+ ,
}22 	
[44 	
HttpGet44	 
]44 
[55 	
Route55	 
(55 
$str55 
)55 
]55 
[66 	
Route66	 
(66 
$str66 
)66 
]66 
[99 	
Route99	 
(99 
$str99 ,
)99, -
]99- .
[:: 	
Route::	 
(:: 
$str:: <
)::< =
]::= >
public;; 
IActionResult;; 
Home;; !
(;;! "
string;;" (
pageName;;) 1
,;;1 2
int;;3 6
	pageIndex;;7 @
,;;@ A
int;;B E
pageSize;;F N
=;;O P
$num;;Q S
);;S T
{<< 	
if>> 
(>> 
string>> 
.>> 
IsNullOrEmpty>> $
(>>$ %
pageName>>% -
)>>- .
||>>/ 1
pageName>>2 :
==>>; =
$str>>> D
)>>D E
{?? 
var@@ 
getPage@@ 
=@@ 
FECategoryViewModel@@ 1
.@@1 2

Repository@@2 <
.@@< =
GetSingleModel@@= K
(@@K L
p@@L M
=>@@N P
p@@Q R
.@@R S
Type@@S W
==@@X Z
(@@[ \
int@@\ _
)@@_ `
SWCmsConstants@@` n
.@@n o
CateType@@o w
.@@w x
Home@@x |
&&@@} 
p
@@Ä Å
.
@@Å Ç
Specificulture
@@Ç ê
==
@@ë ì
CurrentLanguage
@@î £
)
@@£ §
;
@@§ •
ifAA 
(AA 
getPageAA 
.AA 
	IsSucceedAA %
&&AA& (
getPageAA) 0
.AA0 1
DataAA1 5
.AA5 6
ViewAA6 :
!=AA; =
nullAA> B
)AAB C
{BB 
ViewBagCC 
.CC 
	pageClassCC %
=CC& '
getPageCC( /
.CC/ 0
DataCC0 4
.CC4 5
CssClassCC5 =
;CC= >
returnDD 
ViewDD 
(DD  
getPageDD  '
.DD' (
DataDD( ,
)DD, -
;DD- .
}EE 
elseFF 
{GG 
returnHH 
RedirectToActionHH +
(HH+ ,
$strHH, 3
,HH3 4
$strHH5 >
)HH> ?
;HH? @
}II 
}JJ 
elseKK 
{LL 
varMM 
getPageMM 
=MM 
FECategoryViewModelMM 1
.MM1 2

RepositoryMM2 <
.MM< =
GetSingleModelMM= K
(MMK L
pNN 
=>NN 
pNN 
.NN 
SeoNameNN "
==NN# %
pageNameNN& .
&&NN/ 1
pNN2 3
.NN3 4
SpecificultureNN4 B
==NNC E
CurrentLanguageNNF U
)NNU V
;NNV W
ifOO 
(OO 
getPageOO 
.OO 
	IsSucceedOO %
&&OO& (
getPageOO) 0
.OO0 1
DataOO1 5
.OO5 6
ViewOO6 :
!=OO; =
nullOO> B
)OOB C
{PP 
ifQQ 
(QQ 
getPageQQ 
.QQ  
DataQQ  $
.QQ$ %
TypeQQ% )
==QQ* ,
SWCmsConstantsQQ- ;
.QQ; <
CateTypeQQ< D
.QQD E
ListQQE I
)QQI J
{RR 
getPageSS 
.SS  
DataSS  $
.SS$ %
ArticlesSS% -
.SS- .
ItemsSS. 3
.SS3 4
ForEachSS4 ;
(SS; <
aSS< =
=>SS> @
{TT 
aUU 
.UU 
ArticleUU %
.UU% &

DetailsUrlUU& 0
=UU1 2
SwCmsHelperUU3 >
.UU> ?
GetRouterUrlUU? K
(UUK L
$strUUL U
,UUU V
newUUW Z
{UU[ \
aUU] ^
.UU^ _
ArticleUU_ f
.UUf g
SeoNameUUg n
}UUo p
,UUp q
RequestUUr y
,UUy z
UrlUU{ ~
)UU~ 
;	UU Ä
}VV 
)VV 
;VV 
}WW 
ifXX 
(XX 
getPageXX 
.XX  
DataXX  $
.XX$ %
TypeXX% )
==XX* ,
SWCmsConstantsXX- ;
.XX; <
CateTypeXX< D
.XXD E
ListProductXXE P
)XXP Q
{YY 
getPageZZ 
.ZZ  
DataZZ  $
.ZZ$ %
ProductsZZ% -
.ZZ- .
ItemsZZ. 3
.ZZ3 4
ForEachZZ4 ;
(ZZ; <
pZZ< =
=>ZZ> @
{[[ 
p\\ 
.\\ 
Product\\ %
.\\% &

DetailsUrl\\& 0
=\\1 2
SwCmsHelper\\3 >
.\\> ?
GetRouterUrl\\? K
(\\K L
$str\\L U
,\\U V
new\\W Z
{\\[ \
p\\] ^
.\\^ _
Product\\_ f
.\\f g
SeoName\\g n
}\\o p
,\\p q
Request\\r y
,\\y z
Url\\{ ~
)\\~ 
;	\\ Ä
}]] 
)]] 
;]] 
}^^ 
ViewBag__ 
.__ 
	pageClass__ %
=__& '
getPage__( /
.__/ 0
Data__0 4
.__4 5
CssClass__5 =
;__= >
return`` 
View`` 
(``  
getPage``  '
.``' (
Data``( ,
)``, -
;``- .
}aa 
elsebb 
{cc 
returndd 
Redirectdd #
(dd# $
stringdd$ *
.dd* +
Formatdd+ 1
(dd1 2
$strdd2 8
,dd8 9
CurrentLanguagedd: I
)ddI J
)ddJ K
;ddK L
}ee 
}ff 
}gg 	
[ii 	
HttpGetii	 
]ii 
[jj 	
Routejj	 
(jj 
$strjj  
)jj  !
]jj! "
[kk 	
Routekk	 
(kk 
$strkk 1
)kk1 2
]kk2 3
[ll 	
Routell	 
(ll 
$strll A
)llA B
]llB C
publicmm 
IActionResultmm 
Listmm !
(mm! "
stringmm" (
pageNamemm) 1
,mm1 2
intmm3 6
	pageIndexmm7 @
=mmA B
$nummmC D
,mmD E
intmmF I
pageSizemmJ R
=mmS T
$nummmU W
)mmW X
{nn 	
varoo 
getPageoo 
=oo 
FECategoryViewModeloo -
.oo- .

Repositoryoo. 8
.oo8 9
GetSingleModeloo9 G
(ooG H
ppp 
=>pp 
ppp 
.pp 
Typepp 
==pp 
(pp  
intpp  #
)pp# $
SWCmsConstantspp$ 2
.pp2 3
CateTypepp3 ;
.pp; <
Homepp< @
&&ppA C
pppD E
.ppE F
SpecificultureppF T
==ppU W
CurrentLanguageppX g
)ppg h
;pph i
ifqq 
(qq 
getPageqq 
.qq 
	IsSucceedqq !
)qq! "
{rr 
returnss 
Viewss 
(ss 
getPagess #
.ss# $
Datass$ (
)ss( )
;ss) *
}tt 
elseuu 
{vv 
returnww 
Redirectww 
(ww  
stringww  &
.ww& '
Formatww' -
(ww- .
$strww. 4
,ww4 5
CurrentLanguageww6 E
)wwE F
)wwF G
;wwG H
}xx 
}yy 	
[{{ 	
Route{{	 
({{ 
$str{{ 
){{ 
]{{ 
[|| 	
Route||	 
(|| 
$str|| !
)||! "
]||" #
[}} 	
Route}}	 
(}} 
$str}} B
)}}B C
]}}C D
[~~ 	
HttpPost~~	 
,~~ 
HttpGet~~ 
]~~ 
public 
async 
System 
. 
	Threading %
.% &
Tasks& +
.+ ,
Task, 0
<0 1
IActionResult1 >
>> ?
Search@ F
(F G
intG J
	pageIndexK T
=U V
$numW X
,X Y
intZ ]
pageSize^ f
=g h
$numi k
,k l
stringm s
keywordt {
=| }
null	~ Ç
)
Ç É
{
ÄÄ 	
var
ÅÅ 
getArticles
ÅÅ 
=
ÅÅ 
await
ÅÅ #"
InfoArticleViewModel
ÅÅ$ 8
.
ÅÅ8 9

Repository
ÅÅ9 C
.
ÅÅC D!
GetModelListByAsync
ÅÅD W
(
ÅÅW X
article
ÇÇ 
=>
ÇÇ 
article
ÇÇ !
.
ÇÇ! "
Specificulture
ÇÇ" 0
==
ÇÇ1 3
CurrentLanguage
ÇÇ4 C
&&
ÉÉ 
article
ÉÉ 
.
ÉÉ 
Status
ÉÉ $
!=
ÉÉ% '
(
ÉÉ( )
int
ÉÉ) ,
)
ÉÉ, -
SWStatus
ÉÉ- 5
.
ÉÉ5 6
Deleted
ÉÉ6 =
&&
ÑÑ 
(
ÑÑ 
string
ÖÖ 
.
ÖÖ 
IsNullOrEmpty
ÖÖ ,
(
ÖÖ, -
keyword
ÖÖ- 4
)
ÖÖ4 5
||
ÖÖ6 8
article
ÖÖ9 @
.
ÖÖ@ A
Title
ÖÖA F
.
ÖÖF G
Contains
ÖÖG O
(
ÖÖO P
keyword
ÖÖP W
)
ÖÖW X
||
ÜÜ 
(
ÜÜ 
article
ÜÜ #
.
ÜÜ# $
Excerpt
ÜÜ$ +
!=
ÜÜ, .
null
ÜÜ/ 3
&&
ÜÜ4 6
article
ÜÜ7 >
.
ÜÜ> ?
Excerpt
ÜÜ? F
.
ÜÜF G
Contains
ÜÜG O
(
ÜÜO P
keyword
ÜÜP W
)
ÜÜW X
)
ÜÜX Y
)
áá 
,
áá 
$str
àà  
,
àà  !
OrderByDirection
àà" 2
.
àà2 3

Descending
àà3 =
,
àà= >
pageSize
ââ 
,
ââ 
	pageIndex
ââ "
)
ââ" #
;
ââ# $
var
ää 
getProducts
ää 
=
ää 
await
ää #"
InfoProductViewModel
ää$ 8
.
ää8 9

Repository
ää9 C
.
ääC D!
GetModelListByAsync
ääD W
(
ääW X
Product
ãã 
=>
ãã 
Product
ãã !
.
ãã! "
Specificulture
ãã" 0
==
ãã1 3
CurrentLanguage
ãã4 C
&&
åå 
Product
åå 
.
åå 
Status
åå $
!=
åå% '
(
åå( )
int
åå) ,
)
åå, -
SWStatus
åå- 5
.
åå5 6
Deleted
åå6 =
&&
çç 
(
çç 
string
éé 
.
éé 
IsNullOrEmpty
éé ,
(
éé, -
keyword
éé- 4
)
éé4 5
||
éé6 8
Product
éé9 @
.
éé@ A
Title
ééA F
.
ééF G
Contains
ééG O
(
ééO P
keyword
ééP W
)
ééW X
||
èè 
(
èè 
Product
èè #
.
èè# $
Excerpt
èè$ +
!=
èè, .
null
èè/ 3
&&
èè4 6
Product
èè7 >
.
èè> ?
Excerpt
èè? F
.
èèF G
Contains
èèG O
(
èèO P
keyword
èèP W
)
èèW X
)
èèX Y
)
êê 
,
êê 
$str
ëë  
,
ëë  !
OrderByDirection
ëë" 2
.
ëë2 3

Descending
ëë3 =
,
ëë= >
pageSize
íí 
,
íí 
	pageIndex
íí "
)
íí" #
;
íí# $
ViewData
ìì 
[
ìì 
$str
ìì 
]
ìì  
=
ìì! "
getProducts
ìì# .
.
ìì. /
Data
ìì/ 3
;
ìì3 4
return
îî 
View
îî 
(
îî 
getArticles
îî #
.
îî# $
Data
îî$ (
)
îî( )
;
îî) *
}
ïï 	
[
óó 	
HttpGet
óó	 
]
óó 
[
òò 	
Route
òò	 
(
òò 
$str
òò 
)
òò 
]
òò  
[
ôô 	
Route
ôô	 
(
ôô 
$str
ôô ?
)
ôô? @
]
ôô@ A
[
öö 	
HttpPost
öö	 
,
öö 
HttpGet
öö 
]
öö 
public
õõ 
async
õõ 
System
õõ 
.
õõ 
	Threading
õõ %
.
õõ% &
Tasks
õõ& +
.
õõ+ ,
Task
õõ, 0
<
õõ0 1
IActionResult
õõ1 >
>
õõ> ?
Tag
õõ@ C
(
õõC D
int
õõD G
	pageIndex
õõH Q
=
õõR S
$num
õõT U
,
õõU V
int
õõW Z
pageSize
õõ[ c
=
õõd e
$num
õõf h
,
õõh i
string
õõj p
keyword
õõq x
=
õõy z
null
õõ{ 
)õõ Ä
{
úú 	
var
ùù 
getArticles
ùù 
=
ùù 
await
ùù #"
InfoArticleViewModel
ùù$ 8
.
ùù8 9

Repository
ùù9 C
.
ùùC D!
GetModelListByAsync
ùùD W
(
ùùW X
cate
ûû 
=>
ûû 
cate
ûû 
.
ûû 
Specificulture
ûû *
==
ûû+ -
CurrentLanguage
ûû. =
&&
üü 
cate
üü 
.
üü 
Status
üü !
!=
üü" $
(
üü% &
int
üü& )
)
üü) *
SWStatus
üü* 2
.
üü2 3
Deleted
üü3 :
&&
†† 
(
†† 
string
†† 
.
†† 
IsNullOrEmpty
†† +
(
††+ ,
keyword
††, 3
)
††3 4
||
††5 7
cate
††8 <
.
††< =
Tags
††= A
.
††A B
Contains
††B J
(
††J K
keyword
††K R
)
††R S
)
††S T
,
††T U
$str
°°  
,
°°  !
OrderByDirection
°°" 2
.
°°2 3

Descending
°°3 =
,
°°= >
pageSize
¢¢ 
,
¢¢ 
	pageIndex
¢¢ "
)
¢¢" #
;
¢¢# $
var
££ 
getProducts
££ 
=
££ 
await
££ #"
InfoProductViewModel
££$ 8
.
££8 9

Repository
££9 C
.
££C D!
GetModelListByAsync
££D W
(
££W X
Product
§§ 
=>
§§ 
Product
§§ !
.
§§! "
Specificulture
§§" 0
==
§§1 3
CurrentLanguage
§§4 C
&&
•• 
Product
•• 
.
•• 
Status
•• $
!=
••% '
(
••( )
int
••) ,
)
••, -
SWStatus
••- 5
.
••5 6
Deleted
••6 =
&&
¶¶ 
(
¶¶ 
string
ßß 
.
ßß 
IsNullOrEmpty
ßß ,
(
ßß, -
keyword
ßß- 4
)
ßß4 5
||
ßß6 8
Product
ßß9 @
.
ßß@ A
Tags
ßßA E
.
ßßE F
Contains
ßßF N
(
ßßN O
keyword
ßßO V
)
ßßV W
)
®® 
,
®® 
$str
©©  
,
©©  !
OrderByDirection
©©" 2
.
©©2 3

Descending
©©3 =
,
©©= >
pageSize
™™ 
,
™™ 
	pageIndex
™™ "
)
™™" #
;
™™# $
ViewData
´´ 
[
´´ 
$str
´´ 
]
´´  
=
´´! "
getProducts
´´# .
.
´´. /
Data
´´/ 3
;
´´3 4
return
¨¨ 
View
¨¨ 
(
¨¨ 
getArticles
¨¨ #
.
¨¨# $
Data
¨¨$ (
)
¨¨( )
;
¨¨) *
}
≠≠ 	
[
ØØ 	
HttpGet
ØØ	 
]
ØØ 
[
∞∞ 	
Route
∞∞	 
(
∞∞ 
$str
∞∞  
)
∞∞  !
]
∞∞! "
public
±± 
IActionResult
±± 
Article
±± $
(
±±$ %
string
±±% +
pageName
±±, 4
)
±±4 5
{
≤≤ 	
var
≥≥ 
getPage
≥≥ 
=
≥≥ !
FECategoryViewModel
≥≥ -
.
≥≥- .

Repository
≥≥. 8
.
≥≥8 9
GetSingleModel
≥≥9 G
(
≥≥G H
p
¥¥ 
=>
¥¥ 
p
¥¥ 
.
¥¥ 
Type
¥¥ 
==
¥¥ 
(
¥¥  
int
¥¥  #
)
¥¥# $
SWCmsConstants
¥¥$ 2
.
¥¥2 3
CateType
¥¥3 ;
.
¥¥; <
Home
¥¥< @
&&
¥¥A C
p
¥¥D E
.
¥¥E F
Specificulture
¥¥F T
==
¥¥U W
CurrentLanguage
¥¥X g
)
¥¥g h
;
¥¥h i
if
µµ 
(
µµ 
getPage
µµ 
.
µµ 
	IsSucceed
µµ !
)
µµ! "
{
∂∂ 
return
∑∑ 
View
∑∑ 
(
∑∑ 
getPage
∑∑ #
.
∑∑# $
Data
∑∑$ (
)
∑∑( )
;
∑∑) *
}
∏∏ 
else
ππ 
{
∫∫ 
return
ªª 
Redirect
ªª 
(
ªª  
string
ªª  &
.
ªª& '
Format
ªª' -
(
ªª- .
$str
ªª. 4
,
ªª4 5
CurrentLanguage
ªª6 E
)
ªªE F
)
ªªF G
;
ªªG H
}
ºº 
}
ΩΩ 	
[
øø 	
HttpGet
øø	 
]
øø 
[
¿¿ 	
Route
¿¿	 
(
¿¿ 
$str
¿¿ "
)
¿¿" #
]
¿¿# $
[
¡¡ 	
Route
¡¡	 
(
¡¡ 
$str
¡¡ 0
)
¡¡0 1
]
¡¡1 2
public
¬¬ 
IActionResult
¬¬ 
ArticleDetails
¬¬ +
(
¬¬+ ,
string
¬¬, 2
SeoName
¬¬3 :
,
¬¬: ;
string
¬¬< B
CateSeoName
¬¬C N
=
¬¬O P
null
¬¬Q U
)
¬¬U V
{
√√ 	
var
ƒƒ 

getArticle
ƒƒ 
=
ƒƒ  
FEArticleViewModel
ƒƒ /
.
ƒƒ/ 0

Repository
ƒƒ0 :
.
ƒƒ: ;
GetSingleModel
ƒƒ; I
(
ƒƒI J
a
≈≈ 
=>
≈≈ 
a
≈≈ 
.
≈≈ 
SeoName
≈≈ 
==
≈≈ !
SeoName
≈≈" )
&&
≈≈* ,
a
≈≈- .
.
≈≈. /
Specificulture
≈≈/ =
==
≈≈> @
CurrentLanguage
≈≈A P
)
≈≈P Q
;
≈≈Q R
ViewData
∆∆ 
[
∆∆ 
$str
∆∆ "
]
∆∆" #
=
∆∆$ %
CateSeoName
∆∆& 1
;
∆∆1 2
if
«« 
(
«« 

getArticle
«« 
.
«« 
	IsSucceed
«« $
)
««$ %
{
»» 
return
…… 
View
…… 
(
…… 

getArticle
…… &
.
……& '
Data
……' +
)
……+ ,
;
……, -
}
   
else
ÀÀ 
{
ÃÃ 
return
ÕÕ 
Redirect
ÕÕ 
(
ÕÕ  
string
ÕÕ  &
.
ÕÕ& '
Format
ÕÕ' -
(
ÕÕ- .
$str
ÕÕ. 4
,
ÕÕ4 5
CurrentLanguage
ÕÕ6 E
)
ÕÕE F
)
ÕÕF G
;
ÕÕG H
}
ŒŒ 
}
œœ 	
[
—— 	
HttpGet
——	 
]
—— 
[
““ 	
Route
““	 
(
““ 
$str
““ "
)
““" #
]
““# $
[
”” 	
Route
””	 
(
”” 
$str
”” 0
)
””0 1
]
””1 2
public
‘‘ 
IActionResult
‘‘ 
ProductDetails
‘‘ +
(
‘‘+ ,
string
‘‘, 2
SeoName
‘‘3 :
,
‘‘: ;
string
‘‘< B
CateSeoName
‘‘C N
=
‘‘O P
null
‘‘Q U
)
‘‘U V
{
’’ 	
var
÷÷ 

getProduct
÷÷ 
=
÷÷  
FEProductViewModel
÷÷ /
.
÷÷/ 0

Repository
÷÷0 :
.
÷÷: ;
GetSingleModel
÷÷; I
(
÷÷I J
a
◊◊ 
=>
◊◊ 
a
◊◊ 
.
◊◊ 
SeoName
◊◊ 
==
◊◊ !
SeoName
◊◊" )
&&
◊◊* ,
a
◊◊- .
.
◊◊. /
Specificulture
◊◊/ =
==
◊◊> @
CurrentLanguage
◊◊A P
)
◊◊P Q
;
◊◊Q R
ViewData
ÿÿ 
[
ÿÿ 
$str
ÿÿ "
]
ÿÿ" #
=
ÿÿ$ %
CateSeoName
ÿÿ& 1
;
ÿÿ1 2
if
ŸŸ 
(
ŸŸ 

getProduct
ŸŸ 
.
ŸŸ 
	IsSucceed
ŸŸ $
)
ŸŸ$ %
{
⁄⁄ 
return
€€ 
View
€€ 
(
€€ 

getProduct
€€ &
.
€€& '
Data
€€' +
)
€€+ ,
;
€€, -
}
‹‹ 
else
›› 
{
ﬁﬁ 
return
ﬂﬂ 
Redirect
ﬂﬂ 
(
ﬂﬂ  
string
ﬂﬂ  &
.
ﬂﬂ& '
Format
ﬂﬂ' -
(
ﬂﬂ- .
$str
ﬂﬂ. 4
,
ﬂﬂ4 5
CurrentLanguage
ﬂﬂ6 E
)
ﬂﬂE F
)
ﬂﬂF G
;
ﬂﬂG H
}
‡‡ 
}
·· 	
[
‰‰ 	
HttpGet
‰‰	 
]
‰‰ 
[
ÂÂ 	
Route
ÂÂ	 
(
ÂÂ 
$str
ÂÂ #
)
ÂÂ# $
]
ÂÂ$ %
public
ÊÊ 
ActionResult
ÊÊ 
Scriban
ÊÊ #
(
ÊÊ# $
string
ÊÊ$ *
pageName
ÊÊ+ 3
)
ÊÊ3 4
{
ÁÁ 	
Product
ËË 
products
ËË 
=
ËË 
new
ËË "
Product
ËË# *
(
ËË* +
)
ËË+ ,
;
ËË, -
products
ÈÈ 
.
ÈÈ 
Products
ÈÈ 
=
ÈÈ 
new
ÈÈ  #
ProductList
ÈÈ$ /
[
ÈÈ/ 0
$num
ÈÈ0 1
]
ÈÈ1 2
;
ÈÈ2 3
products
ÍÍ 
.
ÍÍ 
Products
ÍÍ 
[
ÍÍ 
$num
ÍÍ 
]
ÍÍ  
=
ÍÍ! "
new
ÍÍ# &
ProductList
ÍÍ' 2
{
ÍÍ3 4
Name
ÍÍ5 9
=
ÍÍ: ;
$str
ÍÍ< A
,
ÍÍA B
Price
ÍÍC H
=
ÍÍI J
$num
ÍÍK M
,
ÍÍM N
Description
ÍÍO Z
=
ÍÍ[ \
$str
ÍÍ] j
}
ÍÍk l
;
ÍÍl m
products
ÎÎ 
.
ÎÎ 
Products
ÎÎ 
[
ÎÎ 
$num
ÎÎ 
]
ÎÎ  
=
ÎÎ! "
new
ÎÎ# &
ProductList
ÎÎ' 2
{
ÎÎ3 4
Name
ÎÎ5 9
=
ÎÎ: ;
$str
ÎÎ< A
,
ÎÎA B
Price
ÎÎC H
=
ÎÎI J
(
ÎÎK L
float
ÎÎL Q
)
ÎÎQ R
$num
ÎÎR V
,
ÎÎV W
Description
ÎÎX c
=
ÎÎd e
$str
ÎÎf s
}
ÎÎt u
;
ÎÎu v
products
ÏÏ 
.
ÏÏ 
Products
ÏÏ 
[
ÏÏ 
$num
ÏÏ 
]
ÏÏ  
=
ÏÏ! "
new
ÏÏ# &
ProductList
ÏÏ' 2
{
ÏÏ3 4
Name
ÏÏ5 9
=
ÏÏ: ;
$str
ÏÏ< A
,
ÏÏA B
Price
ÏÏC H
=
ÏÏI J
$num
ÏÏK M
,
ÏÏM N
Description
ÏÏO Z
=
ÏÏ[ \
$str
ÏÏ] j
}
ÏÏk l
;
ÏÏl m
var
ÓÓ 
getPage
ÓÓ 
=
ÓÓ !
FECategoryViewModel
ÓÓ -
.
ÓÓ- .

Repository
ÓÓ. 8
.
ÓÓ8 9
GetSingleModel
ÓÓ9 G
(
ÓÓG H
p
ÔÔ 
=>
ÔÔ 
p
ÔÔ 
.
ÔÔ 
SeoName
ÔÔ !
==
ÔÔ" $
pageName
ÔÔ% -
&&
ÔÔ. 0
p
ÔÔ1 2
.
ÔÔ2 3
Specificulture
ÔÔ3 A
==
ÔÔB D
CurrentLanguage
ÔÔE T
)
ÔÔT U
;
ÔÔU V
string
ÒÒ 
	tmpsource
ÒÒ 
=
ÒÒ 
getPage
ÒÒ &
.
ÒÒ& '
Data
ÒÒ' +
.
ÒÒ+ ,
View
ÒÒ, 0
.
ÒÒ0 1

SpaContent
ÒÒ1 ;
!=
ÒÒ< >
$str
ÒÒ? A
?
ÒÒB C
getPage
ÒÒD K
.
ÒÒK L
Data
ÒÒL P
.
ÒÒP Q
View
ÒÒQ U
.
ÒÒU V

SpaContent
ÒÒV `
:
ÒÒa b
$str
Ò˚c  
;
˚˚  !
var
¸¸ 
template
¸¸ 
=
¸¸ 
Template
¸¸ #
.
¸¸# $
Parse
¸¸$ )
(
¸¸) *
	tmpsource
¸¸* 3
)
¸¸3 4
;
¸¸4 5
string
˝˝ 
result
˝˝ 
=
˝˝ 
template
˝˝ $
.
˝˝$ %
Render
˝˝% +
(
˝˝+ ,
products
˝˝, 4
)
˝˝4 5
;
˝˝5 6
if
ˇˇ 
(
ˇˇ 
getPage
ˇˇ 
.
ˇˇ 
	IsSucceed
ˇˇ !
)
ˇˇ! "
{
ÄÄ 
return
ÅÅ 
new
ÅÅ 
ContentResult
ÅÅ (
(
ÅÅ( )
)
ÅÅ) *
{
ÇÇ 
Content
ÉÉ 
=
ÉÉ 
result
ÉÉ $
,
ÉÉ$ %
ContentType
ÑÑ 
=
ÑÑ  !
$str
ÑÑ" -
,
ÑÑ- .
}
ÖÖ 
;
ÖÖ 
}
ÜÜ 
else
áá 
{
àà 
return
ââ 
Content
ââ 
(
ââ 
$str
ââ '
)
ââ' (
;
ââ( )
}
ää 
}
ãã 	
private
çç 
class
çç 
Product
çç 
{
éé 	
public
èè 
ProductList
èè 
[
èè 
]
èè  
Products
èè! )
{
èè* +
get
èè, /
;
èè/ 0
set
èè1 4
;
èè4 5
}
èè6 7
}
êê 	
private
íí 
class
íí 
ProductList
íí !
{
ìì 	
public
îî 
string
îî 
Name
îî 
{
îî  
get
îî! $
;
îî$ %
set
îî& )
;
îî) *
}
îî+ ,
public
ïï 
float
ïï 
Price
ïï 
{
ïï  
get
ïï! $
;
ïï$ %
set
ïï& )
;
ïï) *
}
ïï+ ,
public
ññ 
string
ññ 
Description
ññ %
{
ññ& '
get
ññ( +
;
ññ+ ,
set
ññ- 0
;
ññ0 1
}
ññ2 3
}
óó 	
}
òò 
}ôô „
UG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Controllers\InitCmsController.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
. 
Controllers *
{ 
public 

class 
InitCmsController "
:# $
BaseController% 3
{ 
private 
const 
string 
InitUrl $
=% &
$str' 5
;5 6
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
InitCmsController  
(  !
IHostingEnvironment! 4
env5 8
,8 9
UserManager 
< 
ApplicationUser (
>( )
userManager* 5
) 
: 
base 
( 
env 
) 
{ 	
this 
. 
_userManager 
= 
userManager  +
;+ ,
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
$str 
) 
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
async 
System 
. 
	Threading %
.% &
Tasks& +
.+ ,
Task, 0
<0 1
IActionResult1 >
>> ?
Index@ E
(E F
)F G
{ 	
if 
( 
string 
. 
IsNullOrEmpty $
($ %&
GlobalConfigurationService% ?
.? @
Instance@ H
.H I
CmsConfigurationsI Z
.Z [
CmsConnectionString[ n
)n o
)o p
{ 
return   
Redirect   
(    
InitUrl    '
)  ' (
;  ( )
}!! 
else"" 
{## 
var$$ 

superAdmin$$ 
=$$  
await$$! &
_userManager$$' 3
.$$3 4
GetUsersInRoleAsync$$4 G
($$G H
$str$$H T
)$$T U
;$$U V
if%% 
(%% 

superAdmin%% 
.%% 
Count%% $
==%%% '
$num%%( )
)%%) *
{&& 
return'' 
Redirect'' #
(''# $
$"''$ &
/portal/init/step2''& 8
"''8 9
)''9 :
;'': ;
}(( 
else)) 
{** 
return++ 
Redirect++ #
(++# $
$"++$ &
/++& '
{++' (&
GlobalConfigurationService++( B
.++B C
Instance++C K
.++K L
CmsConfigurations++L ]
.++] ^
Language++^ f
}++f g
/Home++g l
"++l m
)++m n
;++n o
},, 
}-- 
}.. 	
}// 
}00 ˜
MG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Models\ErrorViewModel.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
. 
Models %
{ 
public 

class 
ErrorViewModel 
{ 
public		 
string		 
	RequestId		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public 
bool 
ShowRequestId !
=>" $
!% &
string& ,
., -
IsNullOrEmpty- :
(: ;
	RequestId; D
)D E
;E F
} 
} Û
SG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Models\Identity\JWTSettings.cs
	namespace		 	
Swastika		
 
.		 
Cms		 
.		 
Web		 
.		 
Mvc		 
.		 
Models		 %
.		% &
Identity		& .
{

 
public 

class 
JwtSettings 
{ 
public 
string 
	SecretKey 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Issuer 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Audience 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ’	
?G:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Program.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
{ 
public 

static 
class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
=>J L
WebHost"" 
.""  
CreateDefaultBuilder"" (
(""( )
args"") -
)""- .
.## 

UseStartup## 
<## 
Startup## #
>### $
(##$ %
)##% &
;##& '
}$$ 
}%% ›>
?G:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\Startup.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
{ 
public 

partial 
class 
Startup  
{ 
public 
const 
string '
CONST_ROUTE_DEFAULT_CULTURE 7
=8 9
$str: A
;A B
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public!! 
void!! 
ConfigureServices!! %
(!!% &
IServiceCollection!!& 8
services!!9 A
)!!A B
{"" 	
services## 
.## 
	Configure## 
<## 
CookiePolicyOptions## 2
>##2 3
(##3 4
options##4 ;
=>##< >
{$$ 
options&& 
.&& 
CheckConsentNeeded&& *
=&&+ ,
context&&- 4
=>&&5 7
true&&8 <
;&&< =
options'' 
.'' !
MinimumSameSitePolicy'' -
=''. /
SameSiteMode''0 <
.''< =
None''= A
;''A B
}(( 
)(( 
;(( 
ConfigIdentity** 
(** 
services** #
,**# $
Configuration**% 2
,**2 3
Swastika**4 <
.**< =
Cms**= @
.**@ A
Lib**A D
.**D E
SWCmsConstants**E S
.**S T$
CONST_DEFAULT_CONNECTION**T l
)**l m
;**m n
ConfigCookieAuth++ 
(++ 
services++ %
,++% &
Configuration++' 4
)++4 5
;++5 6
ConfigJWTToken,, 
(,, 
services,, #
,,,# $
Configuration,,% 2
),,2 3
;,,3 4
services.. 
... 
AddDbContext.. !
<..! "
SiocCmsContext.." 0
>..0 1
(..1 2
)..2 3
;..3 4
services00 
.00 
	Configure00 
<00 
WebEncoderOptions00 0
>000 1
(001 2
options002 9
=>00: <
options00= D
.00D E
TextEncoderSettings00E X
=00Y Z
new00[ ^
TextEncoderSettings00_ r
(00r s
UnicodeRanges	00s Ä
.
00Ä Å
All
00Å Ñ
)
00Ñ Ö
)
00Ö Ü
;
00Ü á
services11 
.11 
	Configure11 
<11 
FormOptions11 *
>11* +
(11+ ,
options11, 3
=>114 6
options117 >
.11> ?$
MultipartBodyLengthLimit11? W
=11X Y
$num11Z c
)11c d
;11d e
services44 
.44 
AddTransient44 !
<44! "
IEmailSender44" .
,44. /"
AuthEmailMessageSender440 F
>44F G
(44G H
)44H I
;44I J
services55 
.55 
AddTransient55 !
<55! "

ISmsSender55" ,
,55, - 
AuthSmsMessageSender55. B
>55B C
(55C D
)55D E
;55E F
services77 
.77 
AddSingleton77 !
<77! "&
GlobalConfigurationService77" <
>77< =
(77= >
)77> ?
;77? @&
GlobalConfigurationService88 &
.88& '
Instance88' /
.88/ 0

RefreshAll880 :
(88: ;
)88; <
;88< =
services;; 
.;; 
AddMvc;; 
(;; 
options;; #
=>;;$ &
{<< 
options== 
.== 
CacheProfiles== %
.==% &
Add==& )
(==) *
$str==* 3
,==3 4
new>> 
CacheProfile>> $
(>>$ %
)>>% &
{?? 
Duration@@  
=@@! "
$num@@# %
}AA 
)AA 
;AA 
optionsBB 
.BB 
CacheProfilesBB %
.BB% &
AddBB& )
(BB) *
$strBB* 1
,BB1 2
newCC 
CacheProfileCC $
(CC$ %
)CC% &
{DD 
LocationEE  
=EE! "!
ResponseCacheLocationEE# 8
.EE8 9
NoneEE9 =
,EE= >
NoStoreFF 
=FF  !
trueFF" &
}GG 
)GG 
;GG 
}HH 
)HH 
.HH #
SetCompatibilityVersionHH &
(HH& ' 
CompatibilityVersionHH' ;
.HH; <
Version_2_1HH< G
)HHG H
;HHH I
}II 	
publicLL 
voidLL 
	ConfigureLL 
(LL 
IApplicationBuilderLL 1
appLL2 5
,LL5 6
IHostingEnvironmentLL7 J
envLLK N
)LLN O
{MM 	
ifNN 
(NN 
envNN 
.NN 
IsDevelopmentNN !
(NN! "
)NN" #
)NN# $
{OO 
appPP 
.PP %
UseDeveloperExceptionPagePP -
(PP- .
)PP. /
;PP/ 0
appQQ 
.QQ  
UseDatabaseErrorPageQQ (
(QQ( )
)QQ) *
;QQ* +
}RR 
elseSS 
{TT 
appUU 
.UU %
UseDeveloperExceptionPageUU -
(UU- .
)UU. /
;UU/ 0
appWW 
.WW 
UseHstsWW 
(WW 
)WW 
;WW 
}XX 
appZZ 
.ZZ 
UseHttpsRedirectionZZ #
(ZZ# $
)ZZ$ %
;ZZ% &
app[[ 
.[[ 
UseStaticFiles[[ 
([[ 
)[[  
;[[  !
app\\ 
.\\ 
UseCookiePolicy\\ 
(\\  
)\\  !
;\\! "
app^^ 
.^^ 
UseAuthentication^^ !
(^^! "
)^^" #
;^^# $
app`` 
.`` 
UseMvc`` 
(`` 
routes`` 
=>``  
{aa 
routesbb 
.bb 
MapRoutebb 
(bb  
namecc 
:cc 
$strcc %
,cc% &
templatedd 
:dd 
$strdd )
+dd* +'
CONST_ROUTE_DEFAULT_CULTUREdd, G
+ddH I
$strddJ }
)dd} ~
;dd~ 
routesee 
.ee 
MapRouteee 
(ee  
nameff 
:ff 
$strff  
,ff  !
templategg 
:gg 
$strgg )
+gg* +'
CONST_ROUTE_DEFAULT_CULTUREgg, G
+ggH I
$strggJ W
)ggW X
;ggX Y
routeshh 
.hh 
MapRoutehh 
(hh  
nameii 
:ii 
$strii  
,ii  !
templatejj 
:jj 
$strjj )
+jj* +'
CONST_ROUTE_DEFAULT_CULTUREjj, G
+jjH I
$strjjJ Y
)jjY Z
;jjZ [
routeskk 
.kk 
MapRoutekk 
(kk  
namell 
:ll 
$strll #
,ll# $
templatemm 
:mm 
$strmm )
+mm* +'
CONST_ROUTE_DEFAULT_CULTUREmm, G
+mmH I
$strmmJ _
)mm_ `
;mm` a
routesnn 
.nn 
MapRoutenn 
(nn  
nameoo 
:oo 
$stroo #
,oo# $
templatepp 
:pp 
$strpp )
+pp* +'
CONST_ROUTE_DEFAULT_CULTUREpp, G
+ppH I
$strppJ _
)pp_ `
;pp` a
}qq 
)qq 
;qq 
}rr 	
}ss 
}òò ¬
XG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\StartupEnhancementHostingStartup.cs
	namespace 	
Swastika
 
. 
Cms 
. 
Web 
. 
Mvc 
{ 
public		 

class		 ,
 StartupEnhancementHostingStartup		 1
:		2 3
IHostingStartup		4 C
{

 
public 
void 
	Configure 
( 
IWebHostBuilder -
builder. 5
)5 6
{ 	
Console 
. 
Write 
( 
builder !
)! "
;" #
} 	
} 
} ö	
SG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\ViewComponents\FooterNavbar.cs
	namespace

 	
Swastika


 
.

 
Cms

 
.

 
Mvc

 
.

 
ViewComponents

 )
{ 
public 

class 
FooterNavbar 
: 
ViewComponent  -
{ 
public  
IViewComponentResult #
Invoke$ *
(* +
)+ ,
{ 	
string 
culture 
= 
ViewBag $
.$ %
culture% ,
;, -
var 
topCates 
= 
new 
List #
<# $!
InfoCategoryViewModel$ 9
>9 :
(: ;
); <
;< =
return 
View 
( 
topCates  
.  !
OrderBy! (
(( )
c) *
=>+ -
c. /
./ 0
Priority0 8
)8 9
.9 :
ToList: @
(@ A
)A B
)B C
;C D
} 	
} 
} ˝
SG:\_github\Swastika-IO-Core\src\Swastika.Cms.Web.Mvc\ViewComponents\HeaderNavbar.cs
	namespace

 	
Swastika


 
.

 
Cms

 
.

 
Mvc

 
.

 
ViewComponents

 )
{ 
public 

class 
HeaderNavbar 
: 
ViewComponent  -
{ 
public  
IViewComponentResult #
Invoke$ *
(* +
)+ ,
{ 	
string 
culture 
= 
ViewBag $
.$ %
culture% ,
;, -
var 
topCates 
= !
InfoCategoryViewModel 0
.0 1

Repository1 ;
.; <
GetModelListBy< J
( 
c 
=> 
c 
. 
Specificulture &
==' )
culture* 1
&&2 4
c5 6
.6 7 
SiocCategoryPosition7 K
.K L
CountL Q
(Q R
pR S
=>T V
pW X
.X Y

PositionIdY c
==d f
(g h
inth k
)k l
SWCmsConstantsl z
.z {
CatePosition	{ á
.
á à
Top
à ã
)
ã å
>
ç é
$num
è ê
) 
; 
var 
data 
= 
topCates 
.  
Data  $
??% '
new( +
System, 2
.2 3
Collections3 >
.> ?
Generic? F
.F G
ListG K
<K L!
InfoCategoryViewModelL a
>a b
(b c
)c d
;d e
return 
View 
( 
data 
) 
; 
} 	
} 
} 