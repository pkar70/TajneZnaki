﻿Imports pkar.UI.Extensions
Imports pkar.DotNetExtensions

Public NotInheritable Class RejPL
    Inherits Page

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ZmianaQuery()
    End Sub

    Private Sub uiWoj_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If uiPowiat IsNot Nothing Then
            ZmianaQuery()
            uiPowiat.Text = ""
        End If
    End Sub

    Private Sub uiPowiat_TextChanged(sender As Object, e As TextChangedEventArgs)
        ZmianaQuery()
    End Sub

    Private Sub ZmianaQuery()

        Dim sWoj As String = TryCast(uiWoj.SelectedItem, ComboBoxItem)?.Content
        If sWoj.StartsWith("-") Then
            sWoj = ""  ' jeśli nie wybrane, to cokolwiek
        Else
            ' a jeśli wybrane, to ucinamy nazwę
            Dim iInd As Integer = sWoj.IndexOf(" ")
            If iInd > 0 Then sWoj = sWoj.Substring(0, iInd)
        End If

        Dim lista As List(Of JednoEntry) = _slownik.Where(
        Function(x)
            If Not x.s.StartsWithCI(sWoj) Then Return False
            If Not x.s.ContainsCI(uiPowiat.Text) Then Return False
            Return True
        End Function
        ).ToList

        If lista.Count > 50 Then
            uiMatchCount.Text = "Za dużo trafień"
            uiLista.ItemsSource = Nothing
        Else
            uiMatchCount.Text = lista.Count & " matches:"
            uiLista.ItemsSource = lista
        End If

    End Sub


    Private Class JednoEntry
        Public Property s As String

        Public Sub New(tekst As String)
            s = tekst
        End Sub
    End Class

    Private _slownik As JednoEntry() =
        {
        New JednoEntry("BAU powiat augustowski (Augustów)"),
New JednoEntry("BBI powiat bielski (Bielsk Podlaski)"),
New JednoEntry("BGR powiat grajewski (Grajewo)"),
New JednoEntry("BHA powiat hajnowski (Hajnówka)"),
New JednoEntry("BI Białystok"),
New JednoEntry("BIA powiat białostocki (Białystok)"),
New JednoEntry("BKL powiat kolneński (Kolno)"),
New JednoEntry("BL Łomża"),
New JednoEntry("BLM powiat łomżyński (Łomża)"),
New JednoEntry("BMN powiat moniecki (Mońki)"),
New JednoEntry("BS Suwałki"),
New JednoEntry("BSE powiat sejneński (Sejny)"),
New JednoEntry("BSI powiat siemiatycki (Siemiatycze)"),
New JednoEntry("BSK powiat sokólski (Sokółka)"),
New JednoEntry("BSU powiat suwalski (Suwałki)"),
New JednoEntry("BWM powiat wysokomazowiecki (Wysokie Mazowieckie)"),
New JednoEntry("BZA powiat zambrowski (Zambrów)"),
New JednoEntry("CAL powiat aleksandrowski (Aleksandrów Kujawski)"),
New JednoEntry("CB Bydgoszcz"),
New JednoEntry("CBR powiat brodnicki (Brodnica)"),
New JednoEntry("CBY powiat bydgoski (Bydgoszcz)"),
New JednoEntry("CCH powiat chełmiński (Chełmno)"),
New JednoEntry("CG Grudziądz"),
New JednoEntry("CGD powiat golubsko-dobrzyński (Golub-Dobrzyń)"),
New JednoEntry("CGR powiat grudziądzki (Grudziądz)"),
New JednoEntry("CIN powiat inowrocławski (Inowrocław)"),
New JednoEntry("CLI powiat lipnowski (Lipno)"),
New JednoEntry("CMG powiat mogileński (Mogilno)"),
New JednoEntry("CNA powiat nakielski (Nakło nad Notecią)"),
New JednoEntry("CRA powiat radziejowski (Radziejów)"),
New JednoEntry("CRY powiat rypiński (Rypin)"),
New JednoEntry("CSE powiat sępoleński (Sępólno Krajeńskie)"),
New JednoEntry("CSW powiat świecki (Świecie)"),
New JednoEntry("CT Toruń"),
New JednoEntry("CTR powiat toruński (Toruń)"),
New JednoEntry("CTU powiat tucholski (Tuchola)"),
New JednoEntry("CW Włocławek"),
New JednoEntry("CWA powiat wąbrzeski (Wąbrzeźno)"),
New JednoEntry("CWL powiat włocławski (Włocławek)"),
New JednoEntry("CZN powiat żniński (Żnin)"),
New JednoEntry("dawniej: PKO Konin"),
New JednoEntry("dawniej: POZ powiat poznański (Poznań)"),
New JednoEntry("dawniej: SRS Ruda Śląska"),
New JednoEntry("DB Wałbrzych"),
New JednoEntry("DBA powiat wałbrzyski (Wałbrzych)"),
New JednoEntry("DBL powiat bolesławiecki (Bolesławiec)"),
New JednoEntry("DDZ powiat dzierżoniowski (Dzierżoniów)"),
New JednoEntry("DGL powiat głogowski (Głogów)"),
New JednoEntry("DGR powiat górowski (Góra)"),
New JednoEntry("DJ Jelenia Góra"),
New JednoEntry("DJA powiat jaworski (Jawor)"),
New JednoEntry("DJE powiat karkonoski (Jelenia Góra)"),
New JednoEntry("DKA powiat kamiennogórski (Kamienna Góra)"),
New JednoEntry("DKL powiat kłodzki (Kłodzko)"),
New JednoEntry("DL Legnica"),
New JednoEntry("DLB powiat lubański (Lubań)"),
New JednoEntry("DLE powiat legnicki (Legnica)"),
New JednoEntry("DLU powiat lubiński (Lubin)"),
New JednoEntry("DLW powiat lwówecki (Lwówek Śląski)"),
New JednoEntry("DMI powiat milicki (Milicz)"),
New JednoEntry("do 2002 r. NOG powiat olecko-gołdapski (Olecko)"),
New JednoEntry("do 2002 r. NOG powiat olecko-gołdapski (Olecko)"),
New JednoEntry("do 2002 r. STY powiat tyski (Tychy)"),
New JednoEntry("DOA powiat oławski (Oława)"),
New JednoEntry("DOL powiat oleśnicki (Oleśnica)"),
New JednoEntry("DPL powiat polkowicki (Polkowice)"),
New JednoEntry("DSR powiat średzki (Środa Śląska)"),
New JednoEntry("DST powiat strzeliński (Strzelin)"),
New JednoEntry("DSW powiat świdnicki (Świdnica)"),
New JednoEntry("DTR powiat trzebnicki (Trzebnica)"),
New JednoEntry("DW i DX Wrocław"),
New JednoEntry("DWL powiat wołowski (Wołów)"),
New JednoEntry("DWR powiat wrocławski (Wrocław)"),
New JednoEntry("DZA powiat ząbkowicki (Ząbkowice Śląskie)"),
New JednoEntry("DZG powiat zgorzelecki (Zgorzelec)"),
New JednoEntry("DZL powiat złotoryjski (Złotoryja)"),
New JednoEntry("EBE powiat bełchatowski (Bełchatów)"),
New JednoEntry("EBR powiat brzeziński (Brzeziny)"),
New JednoEntry("EKU powiat kutnowski (Kutno)"),
New JednoEntry("EL i ED Łódź"),
New JednoEntry("ELA powiat łaski (Łask)"),
New JednoEntry("ELC powiat łowicki (Łowicz)"),
New JednoEntry("ELE powiat łęczycki (Łęczyca)"),
New JednoEntry("ELW powiat łódzki wschodni (Łódź)"),
New JednoEntry("EOP powiat opoczyński (Opoczno)"),
New JednoEntry("EP Piotrków Trybunalski"),
New JednoEntry("EPA powiat pabianicki (Pabianice)"),
New JednoEntry("EPD powiat poddębicki (Poddębice)"),
New JednoEntry("EPI powiat piotrkowski (Piotrków Trybunalski)"),
New JednoEntry("EPJ powiat pajęczański (Pajęczno)"),
New JednoEntry("ERA powiat radomszczański (Radomsko)"),
New JednoEntry("ERW powiat rawski (Rawa Mazowiecka)"),
New JednoEntry("ES Skierniewice"),
New JednoEntry("ESI powiat sieradzki (Sieradz)"),
New JednoEntry("ESK powiat skierniewicki (Skierniewice)"),
New JednoEntry("ETM powiat tomaszowski (Tomaszów Mazowiecki)"),
New JednoEntry("EWE powiat wieruszowski (Wieruszów)"),
New JednoEntry("EWI powiat wieluński (Wieluń)"),
New JednoEntry("EZD powiat zduńskowolski (Zduńska Wola)"),
New JednoEntry("EZG powiat zgierski (Zgierz)"),
New JednoEntry("FG Gorzów Wielkopolski"),
New JednoEntry("FGW powiat gorzowski (Gorzów Wielkopolski)"),
New JednoEntry("FKR powiat krośnieński (Krosno Odrzańskie)"),
New JednoEntry("FMI powiat międzyrzecki (Międzyrzecz)"),
New JednoEntry("FNW powiat nowosolski (Nowa Sól)"),
New JednoEntry("FSD powiat strzelecko-drezdenecki (Strzelce Krajeńskie)"),
New JednoEntry("FSL powiat słubicki (Słubice)"),
New JednoEntry("FSU powiat sulęciński (Sulęcin)"),
New JednoEntry("FSW powiat świebodziński (Świebodzin)"),
New JednoEntry("FWS powiat wschowski (Wschowa)"),
New JednoEntry("FZ Zielona Góra"),
New JednoEntry("FZA powiat żarski (Żary)"),
New JednoEntry("FZG powiat żagański (Żagań)"),
New JednoEntry("FZI powiat zielonogórski (Zielona Góra)"),
New JednoEntry("GA Gdynia"),
New JednoEntry("GBY powiat bytowski (Bytów)"),
New JednoEntry("GCH powiat chojnicki (Chojnice)"),
New JednoEntry("GCZ powiat człuchowski (Człuchów)"),
New JednoEntry("GD, XD Gdańsk"),
New JednoEntry("GDA powiat gdański (Pruszcz Gdański)"),
New JednoEntry("GKA powiat kartuski (Kartuzy)"),
New JednoEntry("GKS powiat kościerski (Kościerzyna)"),
New JednoEntry("GKW powiat kwidzyński (Kwidzyn)"),
New JednoEntry("GKY powiat kartuski (Kartuzy) zabytkowe"),
New JednoEntry("GLE powiat lęborski (Lębork)"),
New JednoEntry("GMB powiat malborski (Malbork)"),
New JednoEntry("GND powiat nowodworski (Nowy Dwór Gdański)"),
New JednoEntry("GPU powiat pucki (Puck)"),
New JednoEntry("GS Słupsk"),
New JednoEntry("GSL powiat słupski (Słupsk)"),
New JednoEntry("GSP Sopot"),
New JednoEntry("GST powiat starogardzki (Starogard Gdański)"),
New JednoEntry("GSZ powiat sztumski (Sztum)"),
New JednoEntry("GTC powiat tczewski (Tczew)"),
New JednoEntry("GWE powiat wejherowski (Wejherowo)"),
New JednoEntry("GWO powiat wejherowski (Wejherowo)"),
New JednoEntry("HA – Centralne Biuro Antykorupcyjne"),
New JednoEntry("HB – Służba Ochrony Państwa"),
New JednoEntry("HCA Urząd Celno-Skarbowy w Olsztynie"),
New JednoEntry("HCB Urząd Celno-Skarbowy w Białymstoku"),
New JednoEntry("HCC Urząd Celno-Skarbowy w Białej Podlaskiej"),
New JednoEntry("HCD Urząd Celno-Skarbowy w Przemyślu"),
New JednoEntry("HCE Urząd Celno-Skarbowy w Krakowie"),
New JednoEntry("HCF Urząd Celno-Skarbowy w Katowicach"),
New JednoEntry("HCG Urząd Celno-Skarbowy we Wrocławiu"),
New JednoEntry("HCH Urząd Celno-Skarbowy w Rzepinie"),
New JednoEntry("HCJ Urząd Celno-Skarbowy w Szczecinie"),
New JednoEntry("HCK Urząd Celno-Skarbowy w Gdyni"),
New JednoEntry("HCL Urząd Celno-Skarbowy w Warszawie"),
New JednoEntry("HCM Urząd Celno-Skarbowy w Toruniu"),
New JednoEntry("HCN Urząd Celno-Skarbowy w Łodzi"),
New JednoEntry("HCO Urząd Celno-Skarbowy w Poznaniu"),
New JednoEntry("HCP Urząd Celno-Skarbowy w Opolu"),
New JednoEntry("HCR Urząd Celno-Skarbowy w Kielcach"),
New JednoEntry("HK – ABW i Agencja Wywiadu"),
New JednoEntry("HM – SKW i Służba Wywiadu Wojskowego"),
New JednoEntry("HPA Komenda Główna Policji"),
New JednoEntry("HPB Komenda Wojewódzka Policji we Wrocławiu"),
New JednoEntry("HPC Komenda Wojewódzka Policji w Bydgoszczy"),
New JednoEntry("HPD Komenda Wojewódzka Policji w Lublinie"),
New JednoEntry("HPE Komenda Wojewódzka Policji w Gorzowie Wlkp."),
New JednoEntry("HPF Komenda Wojewódzka Policji w Łodzi"),
New JednoEntry("HPG Komenda Wojewódzka Policji w Krakowie"),
New JednoEntry("HPH Komenda Wojewódzka Policji z/s w Radomiu"),
New JednoEntry("HPJ Komenda Wojewódzka Policji w Opolu"),
New JednoEntry("HPK Komenda Wojewódzka w Rzeszowie"),
New JednoEntry("HPL A001–C999, HPL 01AA–99CZ Akademia Policji w Szczytnie"),
New JednoEntry("HPL D001–E999, HPL 01DA–99EZ Szkoła Policji w Pile"),
New JednoEntry("HPL F001–G999, HPL 01FA–99GZ Szkoła Policji w Słupsku"),
New JednoEntry("HPL H001–J999, HPL 01HA–99JZ Centrum Szkolenia Policji w Legionowie"),
New JednoEntry("HPL K001–L999, HPL 01KA–99LZ Szkoła Policji w Katowicach"),
New JednoEntry("HPM Komenda Wojewódzka Policji w Białymstoku"),
New JednoEntry("HPN Komenda Wojewódzka Policji w Gdańsku"),
New JednoEntry("HPP Komenda Wojewódzka Policji w Katowicach"),
New JednoEntry("HPS Komenda Wojewódzka Policji w Kielcach"),
New JednoEntry("HPT Komenda Wojewódzka Policji w Olsztynie"),
New JednoEntry("HPU Komenda Wojewódzka Policji w Poznaniu"),
New JednoEntry("HPW Komenda Wojewódzka policji w Szczecinie"),
New JednoEntry("HPZ Komenda Stołeczna Policji"),
New JednoEntry("HS – Kontrola Skarbowa (old)"),
New JednoEntry("HW – Straż Graniczna"),
New JednoEntry("KBA powiat bocheński (Bochnia)"),
New JednoEntry("KBC powiat bocheński (Bochnia)"),
New JednoEntry("KBR powiat brzeski (Brzesko)"),
New JednoEntry("KCH powiat chrzanowski (Chrzanów)"),
New JednoEntry("KDA powiat dąbrowski (Dąbrowa Tarnowska)"),
New JednoEntry("KGR powiat gorlicki (Gorlice)"),
New JednoEntry("KK Kraków"),
New JednoEntry("KLI powiat limanowski (Limanowa)"),
New JednoEntry("KMI powiat miechowski (Miechów)"),
New JednoEntry("KMY powiat myślenicki (Myślenice)"),
New JednoEntry("KN Nowy Sącz"),
New JednoEntry("KNS powiat nowosądecki (Nowy Sącz)"),
New JednoEntry("KNT powiat nowotarski (Nowy Targ)"),
New JednoEntry("KOL powiat olkuski (Olkusz)"),
New JednoEntry("KOS powiat oświęcimski (Oświęcim)"),
New JednoEntry("KPR powiat proszowicki (Proszowice)"),
New JednoEntry("KR Kraków"),
New JednoEntry("KRA powiat krakowski (Kraków)"),
New JednoEntry("KSU powiat suski (Sucha Beskidzka)"),
New JednoEntry("KT Tarnów"),
New JednoEntry("KTA powiat tarnowski (Tarnów)"),
New JednoEntry("KTT powiat tatrzański (Zakopane)"),
New JednoEntry("KWA powiat wadowicki (Wadowice)"),
New JednoEntry("KWI powiat wielicki (Wieliczka)"),
New JednoEntry("LB Biała Podlaska"),
New JednoEntry("LBI powiat bialski (Biała Podlaska)"),
New JednoEntry("LBL powiat biłgorajski (Biłgoraj)"),
New JednoEntry("LC Chełm"),
New JednoEntry("LCH powiat chełmski (Chełm)"),
New JednoEntry("LHR powiat hrubieszowski (Hrubieszów)"),
New JednoEntry("LJA powiat janowski (Janów Lubelski)"),
New JednoEntry("LKR powiat kraśnicki (Kraśnik)"),
New JednoEntry("LKS powiat krasnostawski (Krasnystaw)"),
New JednoEntry("LLB powiat lubartowski (Lubartów)"),
New JednoEntry("LLE powiat łęczyński (Łęczna)"),
New JednoEntry("LLU powiat łukowski (Łuków)"),
New JednoEntry("LOP powiat opolski (Opole Lubelskie)"),
New JednoEntry("LPA powiat parczewski (Parczew)"),
New JednoEntry("LPU powiat puławski (Puławy)"),
New JednoEntry("LRA powiat radzyński (Radzyń Podlaski)"),
New JednoEntry("LRY powiat rycki (Ryki)"),
New JednoEntry("LSW powiat świdnicki (Świdnik)"),
New JednoEntry("LTM powiat tomaszowski (Tomaszów Lubelski)"),
New JednoEntry("LU Lublin"),
New JednoEntry("LUB powiat lubelski (Lublin)"),
New JednoEntry("LWL powiat włodawski (Włodawa)"),
New JednoEntry("LZ Zamość"),
New JednoEntry("LZA powiat zamojski (Zamość)"),
New JednoEntry("NBA powiat bartoszycki (Bartoszyce)"),
New JednoEntry("NBR powiat braniewski (Braniewo)"),
New JednoEntry("NDZ powiat działdowski (Działdowo)"),
New JednoEntry("NE Elbląg"),
New JednoEntry("NEB powiat elbląski (Elbląg)"),
New JednoEntry("NEL powiat ełcki (Ełk)"),
New JednoEntry("NGI powiat giżycki (Giżycko)"),
New JednoEntry("NGO powiat gołdapski (Gołdap)"),
New JednoEntry("NIL powiat iławski (Iława)"),
New JednoEntry("NKE powiat kętrzyński (Kętrzyn)"),
New JednoEntry("NLI powiat lidzbarski (Lidzbark Warmiński)"),
New JednoEntry("NMR powiat mrągowski (Mrągowo)"),
New JednoEntry("NNI powiat nidzicki (Nidzica)"),
New JednoEntry("NNM powiat nowomiejski (Nowe Miasto Lubawskie)"),
New JednoEntry("NO Olsztyn"),
New JednoEntry("NOE powiat olecki (Olecko)"),
New JednoEntry("NOL powiat olsztyński (Olsztyn)"),
New JednoEntry("NOS powiat ostródzki (Ostróda)"),
New JednoEntry("NPI powiat piski (Pisz)"),
New JednoEntry("NSZ powiat szczycieński (Szczytno)"),
New JednoEntry("NWE powiat węgorzewski (Węgorzewo) (od 1 stycznia 2002)"),
New JednoEntry("OB powiat brzeski (Brzeg)"),
New JednoEntry("OGL powiat głubczycki (Głubczyce)"),
New JednoEntry("OK powiat kędzierzyńsko-kozielski (Kędzierzyn-Koźle)"),
New JednoEntry("OKL powiat kluczborski (Kluczbork)"),
New JednoEntry("OKR powiat krapkowicki (Krapkowice)"),
New JednoEntry("ONA powiat namysłowski (Namysłów)"),
New JednoEntry("ONY powiat nyski (Nysa)"),
New JednoEntry("OOL powiat oleski (Olesno)"),
New JednoEntry("OP Opole"),
New JednoEntry("OPO powiat opolski (Opole)"),
New JednoEntry("OPR powiat prudnicki (Prudnik)"),
New JednoEntry("OST powiat strzelecki (Strzelce Opolskie)"),
New JednoEntry("PA Kalisz"),
New JednoEntry("PCH powiat chodzieski (Chodzież)"),
New JednoEntry("PCT powiat czarnkowsko-trzcianecki (Czarnków)"),
New JednoEntry("PGN powiat gnieźnieński (Gniezno)"),
New JednoEntry("PGO powiat grodziski (Grodzisk Wielkopolski)"),
New JednoEntry("PGS powiat gostyński (Gostyń)"),
New JednoEntry("PJA powiat jarociński (Jarocin)"),
New JednoEntry("PK Kalisz"),
New JednoEntry("PKA powiat kaliski (Kalisz)"),
New JednoEntry("PKE powiat kępiński (Kępno)"),
New JednoEntry("PKL powiat kolski (Koło)"),
New JednoEntry("PKN powiat koniński (Konin)"),
New JednoEntry("PKR powiat krotoszyński (Krotoszyn)"),
New JednoEntry("PKS powiat kościański (Kościan)"),
New JednoEntry("PL Leszno"),
New JednoEntry("PLE powiat leszczyński (Leszno)"),
New JednoEntry("PMI powiat międzychodzki (Międzychód)"),
New JednoEntry("PN Konin"),
New JednoEntry("PNT powiat nowotomyski (Nowy Tomyśl)"),
New JednoEntry("PO Poznań"),
New JednoEntry("POB powiat obornicki (Oborniki)"),
New JednoEntry("POS powiat ostrowski (Ostrów Wielkopolski)"),
New JednoEntry("POT powiat ostrzeszowski (Ostrzeszów)"),
New JednoEntry("PP powiat pilski (Piła)"),
New JednoEntry("PPL powiat pleszewski (Pleszew)"),
New JednoEntry("PRA powiat rawicki (Rawicz)"),
New JednoEntry("PSE powiat śremski (Śrem)"),
New JednoEntry("PSL powiat słupecki (Słupca)"),
New JednoEntry("PSR powiat średzki (Środa Wielkopolska)"),
New JednoEntry("PSZ powiat szamotulski (Szamotuły)"),
New JednoEntry("PTU powiat turecki (Turek)"),
New JednoEntry("PWA powiat wągrowiecki (Wągrowiec)"),
New JednoEntry("PWL powiat wolsztyński (Wolsztyn)"),
New JednoEntry("PWR powiat wrzesiński (Września)"),
New JednoEntry("PY Poznań"),
New JednoEntry("PZ powiat poznański (Poznań)"),
New JednoEntry("PZL powiat złotowski (Złotów)"),
New JednoEntry("RBI powiat bieszczadzki (Ustrzyki Dolne)"),
New JednoEntry("RBR powiat brzozowski (Brzozów)"),
New JednoEntry("RDE powiat dębicki (Dębica)"),
New JednoEntry("RJA powiat jarosławski (Jarosław)"),
New JednoEntry("RJS powiat jasielski (Jasło)"),
New JednoEntry("RK Krosno"),
New JednoEntry("RKL powiat kolbuszowski (Kolbuszowa)"),
New JednoEntry("RKR powiat krośnieński (Krosno)"),
New JednoEntry("RLA powiat łańcucki (Łańcut)"),
New JednoEntry("RLE powiat leżajski (Leżajsk)"),
New JednoEntry("RLS powiat leski (Lesko) (od 1 stycznia 2002)"),
New JednoEntry("RLU powiat lubaczowski (Lubaczów)"),
New JednoEntry("RMI powiat mielecki (Mielec)"),
New JednoEntry("RNI powiat niżański (Nisko)"),
New JednoEntry("RP Przemyśl"),
New JednoEntry("RPR powiat przemyski (Przemyśl)"),
New JednoEntry("RPZ powiat przeworski (Przeworsk)"),
New JednoEntry("RRS powiat ropczycko-sędziszowski (Ropczyce)"),
New JednoEntry("RSA powiat sanocki (Sanok)"),
New JednoEntry("RSR powiat strzyżowski (Strzyżów)"),
New JednoEntry("RST powiat stalowowolski (Stalowa Wola)"),
New JednoEntry("RT Tarnobrzeg"),
New JednoEntry("RTA powiat tarnobrzeski (Tarnobrzeg)"),
New JednoEntry("RZ Rzeszów"),
New JednoEntry("RZE powiat rzeszowski (Rzeszów)"),
New JednoEntry("SB Bielsko-Biała"),
New JednoEntry("SBE powiat będziński (Będzin)"),
New JednoEntry("SBI powiat bielski (Bielsko-Biała)"),
New JednoEntry("SBL powiat bieruńsko-lędziński (Bieruń)"),
New JednoEntry("SC Częstochowa"),
New JednoEntry("SCI powiat cieszyński (Cieszyn)"),
New JednoEntry("SCn powiat cieszyński (Cieszyn)"),
New JednoEntry("SCZ powiat częstochowski (Częstochowa)"),
New JednoEntry("SD Dąbrowa Górnicza"),
New JednoEntry("SG Gliwice"),
New JednoEntry("SGL powiat gliwicki (Gliwice)"),
New JednoEntry("SH Chorzów"),
New JednoEntry("SI Siemianowice Śląskie"),
New JednoEntry("SJ Jaworzno"),
New JednoEntry("SJZ Jastrzębie-Zdrój"),
New JednoEntry("SK Katowice"),
New JednoEntry("SKL powiat kłobucki (Kłobuck)"),
New JednoEntry("SL Ruda Śląska"),
New JednoEntry("SLU powiat lubliniecki (Lubliniec)"),
New JednoEntry("SM Mysłowice"),
New JednoEntry("SMI powiat mikołowski (Mikołów)"),
New JednoEntry("SMY powiat myszkowski (Myszków)"),
New JednoEntry("SO Sosnowiec"),
New JednoEntry("SPI Piekary Śląskie"),
New JednoEntry("SPS powiat pszczyński (Pszczyna)"),
New JednoEntry("SR Rybnik"),
New JednoEntry("SRB powiat rybnicki (Rybnik)"),
New JednoEntry("SRC powiat raciborski (Racibórz)"),
New JednoEntry("ST Tychy"),
New JednoEntry("STA powiat tarnogórski (Tarnowskie Góry)"),
New JednoEntry("SW Świętochłowice"),
New JednoEntry("SWD powiat wodzisławski (Wodzisław Śląski)"),
New JednoEntry("SWZ powiat wodzisławski (Wodzisław Śląski)"),
New JednoEntry("SY Bytom"),
New JednoEntry("SZ Zabrze"),
New JednoEntry("SZA powiat zawierciański (Zawiercie)"),
New JednoEntry("SZO Żory"),
New JednoEntry("SZY powiat żywiecki (Żywiec)"),
New JednoEntry("TBU powiat buski (Busko Zdrój)"),
New JednoEntry("TJE powiat jędrzejowski (Jędrzejów)"),
New JednoEntry("TK Kielce"),
New JednoEntry("TKA powiat kazimierski (Kazimierza Wielka)"),
New JednoEntry("TKI powiat kielecki (Kielce)"),
New JednoEntry("TKN powiat konecki (Końskie)"),
New JednoEntry("TLW powiat włoszczowski (Włoszczowa)"),
New JednoEntry("TOP powiat opatowski (Opatów)"),
New JednoEntry("TOS powiat ostrowiecki (Ostrowiec Świętokrzyski)"),
New JednoEntry("TPI powiat pińczowski (Pińczów)"),
New JednoEntry("TSA powiat sandomierski (Sandomierz)"),
New JednoEntry("TSK powiat skarżyski (Skarżysko-Kamienna)"),
New JednoEntry("TST powiat starachowicki (Starachowice)"),
New JednoEntry("TSZ powiat staszowski (Staszów)"),
New JednoEntry("UA – samochody osobowe, osobowo-terenowe oraz specjalne na podwoziu osobowym (osobowo-terenowym)"),
New JednoEntry("UB – transportery opancerzone"),
New JednoEntry("UC – samochody osobowo-ciężarowe (dostawcze)"),
New JednoEntry("UD – autobusy"),
New JednoEntry("UE – samochody ciężarowe i ciężarowo-terenowe o przeznaczeniu transportowym"),
New JednoEntry("UG – pojazdy specjalne na podwoziu ciężarowym (ciężarowo-terenowym)"),
New JednoEntry("UI – przyczepy transportowe"),
New JednoEntry("UJ – przyczepy specjalne"),
New JednoEntry("UK – motocykle"),
New JednoEntry("UL – pojazdy przyjmowane z gospodarki narodowej podczas mobilizacji (pojazdy posiadające obecnie 'cywilne' numery rejestracyjne)"),
New JednoEntry("VWR powiat wrocławski (Wrocław) zabytkowe"),
New JednoEntry("W001  Stany Zjednoczone"),
New JednoEntry("W002  Wielka Brytania"),
New JednoEntry("W003  Francja"),
New JednoEntry("W004  Kanada"),
New JednoEntry("W005  Niemcy"),
New JednoEntry("W006  Holandia"),
New JednoEntry("W007  Włochy"),
New JednoEntry("W008  Austria"),
New JednoEntry("W009  Japonia"),
New JednoEntry("W010  Turcja"),
New JednoEntry("W011  Belgia"),
New JednoEntry("W012  Dania"),
New JednoEntry("W013  Norwegia"),
New JednoEntry("W014  Grecja"),
New JednoEntry("W015  Australia"),
New JednoEntry("W016  Algieria"),
New JednoEntry("W017  Afganistan"),
New JednoEntry("W018  Argentyna"),
New JednoEntry("W019  Brazylia"),
New JednoEntry("W020  Bangladesz"),
New JednoEntry("W021  Egipt"),
New JednoEntry("W022  Ekwador"),
New JednoEntry("W023  Finlandia"),
New JednoEntry("W024  Hiszpania"),
New JednoEntry("W025  Irak"),
New JednoEntry("W026  Iran"),
New JednoEntry("W027  Indie"),
New JednoEntry("W028  Indonezja"),
New JednoEntry("W029  Kolumbia"),
New JednoEntry("W030  Malezja"),
New JednoEntry("W031  Libia"),
New JednoEntry("W032  Maroko"),
New JednoEntry("W033  Meksyk"),
New JednoEntry("W034  Nigeria"),
New JednoEntry("W035  Pakistan"),
New JednoEntry("W036  Portugalia"),
New JednoEntry("W037  Palestyna"),
New JednoEntry("W038  Syria"),
New JednoEntry("W039  Szwecja"),
New JednoEntry("W040  Szwajcaria"),
New JednoEntry("W041  Tunezja"),
New JednoEntry("W042  Tajlandia"),
New JednoEntry("W043  Wenezuela"),
New JednoEntry("W044  Urugwaj"),
New JednoEntry("W045  Peru"),
New JednoEntry("W046  Jemen"),
New JednoEntry("W047  Kostaryka"),
New JednoEntry("W048  Demokratyczna Republika Konga"),
New JednoEntry("W049  Izrael"),
New JednoEntry("W050  Nikaragua"),
New JednoEntry("W051  Chile"),
New JednoEntry("W052  Watykan"),
New JednoEntry("W053  Korea Południowa"),
New JednoEntry("W054 Przedstawicielstwo Komisji Wspólnot Europejskich"),
New JednoEntry("W055  Irlandia"),
New JednoEntry("W056 Bank Światowy"),
New JednoEntry("W057 Międzynarodowy Fundusz Walutowy"),
New JednoEntry("W058  Filipiny"),
New JednoEntry("W059 Międzynarodowa Korporacja Finansowa"),
New JednoEntry("W060  Południowa Afryka"),
New JednoEntry("W061 Biuro Instytucji Demokratycznych i Praw Człowieka OBWE"),
New JednoEntry("W062  Cypr"),
New JednoEntry("W063  Kuwejt"),
New JednoEntry("W064  Organizacja Narodów Zjednoczonych"),
New JednoEntry("W065  Rosja"),
New JednoEntry("W066  Słowacja (do 1990  NRD)"),
New JednoEntry("W067  Czechy"),
New JednoEntry("W068  Bułgaria"),
New JednoEntry("W069  Węgry"),
New JednoEntry("W070  Rumunia"),
New JednoEntry("W071  Wietnam"),
New JednoEntry("W072  Serbia"),
New JednoEntry("W073  Korea Północna"),
New JednoEntry("W074  Kuba"),
New JednoEntry("W075  Albania"),
New JednoEntry("W076  Chiny"),
New JednoEntry("W077  Mongolia"),
New JednoEntry("W078 Międzynarodowa Organizacja Pracy"),
New JednoEntry("W079 Organizacja Kooperacyjna ds. Kolei"),
New JednoEntry("W080 Klub Dyplomatyczny"),
New JednoEntry("W081  Laos"),
New JednoEntry("W082  Angola"),
New JednoEntry("W083  Ukraina"),
New JednoEntry("W084 Europejski Bank Odbudowy i Rozwoju"),
New JednoEntry("W085  Litwa"),
New JednoEntry("W086  Białoruś"),
New JednoEntry("W087  Łotwa"),
New JednoEntry("W088  Chorwacja"),
New JednoEntry("W089  Liban"),
New JednoEntry("W090  Słowenia"),
New JednoEntry("W091  Gwatemala"),
New JednoEntry("W092  Estonia"),
New JednoEntry("W093  Macedonia Północna"),
New JednoEntry("W094  Mołdawia"),
New JednoEntry("W095 Izrael"),
New JednoEntry("W096  Armenia"),
New JednoEntry("W097  Sri Lanka"),
New JednoEntry("W098  Kazachstan"),
New JednoEntry("W099  Arabia Saudyjska"),
New JednoEntry("W100  Gruzja"),
New JednoEntry("W101  Uzbekistan"),
New JednoEntry("W102 Międzynarodowa Organizacja ds. Migracji"),
New JednoEntry("W103  Nowa Zelandia"),
New JednoEntry("W104  Azerbejdżan"),
New JednoEntry("W105  Suwerenny Wojskowy Zakon Maltański"),
New JednoEntry("W106  Kambodża"),
New JednoEntry("W107 Frontex"),
New JednoEntry("W108  Luksemburg"),
New JednoEntry("W109  Bośnia i Hercegowina"),
New JednoEntry("W110  Panama"),
New JednoEntry("W111  Katar"),
New JednoEntry("W112  Malta"),
New JednoEntry("W113  Zjednoczone Emiraty Arabskie"),
New JednoEntry("W114  Czarnogóra"),
New JednoEntry("W115  Senegal"),
New JednoEntry("W116  Bangladesz"),
New JednoEntry("W117  Rwanda"),
New JednoEntry("WA Warszawa Białołęka"),
New JednoEntry("WB Warszawa Bemowo"),
New JednoEntry("WBR powiat białobrzeski (Białobrzegi)"),
New JednoEntry("WCI powiat ciechanowski (Ciechanów)"),
New JednoEntry("WD Warszawa Bielany"),
New JednoEntry("WE Warszawa Mokotów"),
New JednoEntry("WF Warszawa Praga-Południe"),
New JednoEntry("WG powiat garwoliński (Garwolin)"),
New JednoEntry("WGM powiat grodziski (Grodzisk Mazowiecki)"),
New JednoEntry("WGR powiat grójecki (Grójec)"),
New JednoEntry("WGS powiat gostyniński (Gostynin)"),
New JednoEntry("WH Warszawa Praga-Północ"),
New JednoEntry("WI Warszawa Śródmieście"),
New JednoEntry("WJ Warszawa Targówek"),
New JednoEntry("WK Warszawa Ursus"),
New JednoEntry("WKZ powiat kozienicki (Kozienice)"),
New JednoEntry("WL powiat legionowski (Legionowo)"),
New JednoEntry("WLI powiat lipski (Lipsko)"),
New JednoEntry("WLS powiat łosicki (Łosice)"),
New JednoEntry("WM powiat miński (Mińsk Mazowiecki)"),
New JednoEntry("WMA powiat makowski (Maków Mazowiecki)"),
New JednoEntry("WML powiat mławski (Mława)"),
New JednoEntry("WN Warszawa Ursynów"),
New JednoEntry("WND powiat nowodworski (Nowy Dwór Mazowiecki)"),
New JednoEntry("WO Ostrołęka"),
New JednoEntry("WOR powiat ostrowski (Ostrów Mazowiecka)"),
New JednoEntry("WOS powiat ostrołęcki (Ostrołęka)"),
New JednoEntry("WOT powiat otwocki (Otwock)"),
New JednoEntry("WP Płock"),
New JednoEntry("WPA powiat piaseczyński (Piaseczno)"),
New JednoEntry("WPI powiat piaseczyński (Piaseczno)"),
New JednoEntry("WPL powiat płocki (Płock)"),
New JednoEntry("WPN powiat płoński (Płońsk)"),
New JednoEntry("WPP powiat pruszkowski (Pruszków)"),
New JednoEntry("WPR powiat pruszkowski (Pruszków)"),
New JednoEntry("WPS powiat pruszkowski (Pruszków)"),
New JednoEntry("WPU powiat pułtuski (Pułtusk)"),
New JednoEntry("WPY powiat przysuski (Przysucha)"),
New JednoEntry("WPZ powiat przasnyski (Przasnysz)"),
New JednoEntry("WR Radom"),
New JednoEntry("WRA powiat radomski (Radom)"),
New JednoEntry("WS Siedlce"),
New JednoEntry("WSC powiat sochaczewski (Sochaczew)"),
New JednoEntry("WSE powiat sierpecki (Sierpc)"),
New JednoEntry("WSI powiat siedlecki (Siedlce)"),
New JednoEntry("WSK powiat sokołowski (Sokołów Podlaski)"),
New JednoEntry("WSZ powiat szydłowiecki (Szydłowiec)"),
New JednoEntry("WT Warszawa Wawer"),
New JednoEntry("WU Warszawa Ochota"),
New JednoEntry("WW ....A, ....C, ....E, ....X, ....Y Warszawa Rembertów"),
New JednoEntry("WW ....F, ....G, ....H, ....J, ....W Warszawa Wilanów"),
New JednoEntry("WW ....K,  ....L, ....M, ....N, ....V, ....R, ....S, ....U, ....P, ...T, ...W*, ...X* Warszawa Włochy"),
New JednoEntry("WWE powiat węgrowski (Węgrów)"),
New JednoEntry("WWL powiat wołomiński (Wołomin)"),
New JednoEntry("WWV powiat wołomiński (Wołomin)"),
New JednoEntry("WWY powiat wyszkowski (Wyszków)"),
New JednoEntry("WX Warszawa Żoliborz"),
New JednoEntry("WY Warszawa Wola"),
New JednoEntry("WZ powiat warszawski zachodni (Ożarów Mazowiecki)"),
New JednoEntry("WZU powiat żuromiński (Żuromin)"),
New JednoEntry("WZW powiat zwoleński (Zwoleń)"),
New JednoEntry("WZY powiat żyrardowski (Żyrardów)"),
New JednoEntry("ZBI powiat białogardzki (Białogard)"),
New JednoEntry("ZCH powiat choszczeński (Choszczno)"),
New JednoEntry("ZDR powiat drawski (Drawsko Pomorskie)"),
New JednoEntry("ZGL powiat goleniowski (Goleniów)"),
New JednoEntry("ZGR powiat gryfiński (Gryfino)"),
New JednoEntry("ZGY powiat gryficki (Gryfice)"),
New JednoEntry("ZK Koszalin"),
New JednoEntry("ZKA powiat kamieński (Kamień Pomorski)"),
New JednoEntry("ZKL powiat kołobrzeski (Kołobrzeg)"),
New JednoEntry("ZKO powiat koszaliński (Koszalin)"),
New JednoEntry("ZLO powiat łobeski (Łobez) (od 1 stycznia 2002)"),
New JednoEntry("ZMY powiat myśliborski (Myślibórz)"),
New JednoEntry("ZPL powiat policki (Police)"),
New JednoEntry("ZPY powiat pyrzycki (Pyrzyce)"),
New JednoEntry("ZS Szczecin"),
New JednoEntry("ZSD powiat świdwiński (Świdwin)"),
New JednoEntry("ZSL powiat sławieński (Sławno)"),
New JednoEntry("ZST powiat stargardzki (Stargard)"),
New JednoEntry("ZSW Świnoujście"),
New JednoEntry("ZSZ powiat szczecinecki (Szczecinek)"),
New JednoEntry("ZWA powiat wałecki (Wałcz)"),
New JednoEntry("ZZ Szczecin")
        }


End Class