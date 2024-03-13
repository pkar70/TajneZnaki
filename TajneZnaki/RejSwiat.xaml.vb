'===== rejestracje świat 
'* panstwa: - ikonka obrazek PL
'https://pl.wikipedia.org/wiki/Mi%C4%99dzynarodowy_kod_samochodowy

'wyszukiwarka wg kraju, wg symbolu, symbol: z kbd, albo z spin/rotate/list


Imports pkar.DotNetExtensions

Public NotInheritable Class RejSwiat
    Inherits Page

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ZmianaQuery()
    End Sub

    Private Sub uiSymbol_TextChanged(sender As Object, e As TextChangedEventArgs)
        ZmianaQuery()
    End Sub

    Private Sub uiKraj_TextChanged(sender As Object, e As TextChangedEventArgs)
        If uiKraj.Text.Length < 2 Then Return
        ZmianaQuery()
    End Sub

    Private Sub uiCheckbox_Changed(sender As Object, e As RoutedEventArgs)
        ' zarówno historii, jak i detailsów
        ZmianaQuery()
    End Sub

    Private Sub ZmianaQuery()

        Dim lista As List(Of JednoEntry) = _slownik.Where(
        Function(x)
            If Not x.symbol.ContainsCI(uiSymbol.Text) Then Return False
            If Not x.kraj.ContainsCI(uiKraj.Text) Then Return False

            If Not uiHistory.IsChecked AndAlso x.rokDo <> "" Then Return False

            Return True
        End Function
        ).ToList

        If lista.Count > 50 Then
            uiMatchCount.Text = "Za dużo trafień"
            uiLista.ItemsSource = Nothing
        Else
            uiMatchCount.Text = lista.Count & " matches:"
            _ShowDetails = uiDetails.IsChecked
            _ShowHistory = uiHistory.IsChecked
            uiLista.ItemsSource = lista
        End If

    End Sub




    Private Class JednoEntry
        Public Property symbol As String
        Public Property kraj As String
        Public Property rokOd As String
        Public Property rokDo As String
        Public Property symbolPrev As String
        Public Property symbolNext As String
        Public Property comment As String

        Public Sub New(symbol As String, kraj As String, rokOd As String, rokDo As String, symbolPrev As String, symbolNext As String, comment As String)
            Me.symbol = symbol
            Me.kraj = kraj
            Me.rokOd = rokOd
            Me.rokDo = rokDo
            Me.symbolPrev = symbolPrev
            Me.symbolNext = symbolNext
            Me.comment = comment
        End Sub
    End Class

    Private _slownik As JednoEntry() =
        {
New JednoEntry("ADN", "Aden", "1938", "1980", "", "Y", "also known as South Yemen, People's Democratic Republic of Yemen (1967), PL: do ok. 1990, używany obecnie w części Jemenu)"),
New JednoEntry("AFG", "Afganistan", "1971", "", "", "", ""),
New JednoEntry("SWA", "Afryka Południowo-Zachodnia", "1935", "1990", "", "", "Now Namibia, PL: do 1966"),
New JednoEntry("AL", "Albania", "1934", "", "", "", ""),
New JednoEntry("GBA", "Alderney", "1924", "", "GB", "", "(United Kingdom of) Great Britain & Northern Ireland – Alderney"),
New JednoEntry("DZ", "Algieria", "1962", "", "F", "", "Djazayer (Algerian Arabic: جزائر); formerly part of France. "),
New JednoEntry("AND", "Andora", "1957", "", "", "", ""),
New JednoEntry("PANG", "Angola", "1932", "1956", "", "P, AN", "From 1932. Formerly part of Portugal"),
New JednoEntry("AN ", "Angola", "", "", "", "", ""),
New JednoEntry("AG", "Antigua i Barbuda", "", "", "", "", ""),
New JednoEntry("NA", "Antyle Holenderskie", "1957", "2010", "", "", "The Netherlands Antilles were dissolved in 2010."),
New JednoEntry("KSA", "Arabia Saudyjska", "1973", "", "SA", "", "Kingdom of Saudi Arabia"),
New JednoEntry("SA", "Arabia Saudyjska", "1973", "", "", "KSA", ""),
New JednoEntry("RA", "Argentyna", "1927", "", "", "", "República Argentina (Spanish)"),
New JednoEntry("AM", "Armenia", "1992", "", "SU", "", "Formerly part of the Soviet Union. "),
New JednoEntry("ARU ", "Aruba", "", "", "", "", ""),
New JednoEntry("AUS", "Australia", "1954", "", "", "", ""),
New JednoEntry("A", "Austria", "1910", "", "", "", ""),
New JednoEntry("AUT ", "Autonomia Palestyńska", "", "", "", "", ""),
New JednoEntry("AZ", "Azerbejdżan", "1993", "", "SU", "", "Formerly part of the Soviet Union"),
New JednoEntry("BS", "Bahamy", "1950", "", "", "", ""),
New JednoEntry("BRN", "Bahrain", "1954", "", "", "", ""),
New JednoEntry("BD", "Bangladesz", "1978", "", "PAK", "", "Formerly East Pakistan"),
New JednoEntry("BDS", "Barbados", "1956", "", "", "", ""),
New JednoEntry("BL", "Basutoland", "1935", "1967", "", "LS", "obecnie Lesotho"),
New JednoEntry("BP", "Bechuanaland Protectorate", "", "1966", "", "", "Now Botswana"),
New JednoEntry("B", "Belgia", "1909", "", "", "", ""),
New JednoEntry("BH", "Belize", "1938", "", "", "", "Formerly British Honduras. Still officially registered as BH as of 2007. New driving licenses appear to have 'BZ' instead of 'BH' as Belize's code.[10]"),
New JednoEntry("BZ ", "Belize", "", "", "", "", ""),
New JednoEntry("DY", "Benin", "1961", "", "", "", "Dahomey (name until 1975). Uses RB unofficially (République du Bénin). Part of AOF (Afrique occidentale française) − 1960"),
New JednoEntry("BHT", "Bhutan", "", "", "", "", ""),
New JednoEntry("BY", "Białoruś", "1992", "", "SU", "", "formerly part of the Soviet Union. The UN was officially notified of the change from SU to BY only in 2004"),
New JednoEntry("BA", "Birma", "1937", "1956", "", "BUR, MYA", ""),
New JednoEntry("BUR ", "Birma", "1956", "", "BA", "MYA", "Previously known as Burma"),
New JednoEntry("BOL", "Bolivia", "1967", "", "RB", "", ""),
New JednoEntry("RB", "Boliwia", "1936", "1967", "", "BOL", "República de Bolivia"),
New JednoEntry("BIH", "Bosnia and Herzegovina", "1992", "", "SHS, Y, YU", "", "Bosna i Hercegovina / Formerly part of the Kingdom of Serbs, Croats and Slovenes Kraljevina Srba, Hrvata i Slovenaca (Serbo-Croatian), then part of Yugoslavia"),
New JednoEntry("BW", "Botswana", "2003", "", "BP", "", "Officially used by Botswana since 2003. Formerly RB (Republic of Botswana) until 2004; Bechuanaland Protectorate before 1966."),
New JednoEntry("RB", "Botswana", "1967", "", "", "", "Republic of Botswana, oficjalnie: BW"),
New JednoEntry("BR", "Brazylia", "1930", "", "", "", ""),
New JednoEntry("BI", "British India", "1924", "1947", "", "", ""),
New JednoEntry("BVI", "British Virgin Islands", "1910", "", "", "", ""),
New JednoEntry("BRU", "Brunei", "1956", "", "", "", ""),
New JednoEntry("EA", "Brytyjska Afryka Wschodnia", "1932", "1938", "", "", "East Africa"),
New JednoEntry("BS ", "Brytyjskie Somaliland", "1935", "1960", "", "SO ", "obecnie Somalia"),
New JednoEntry("BG", "Bułgaria", "1909", "", "", "", ""),
New JednoEntry("BF", "Burkina Faso", "1990", "", "RHV, HV", "", "Until August 2003, 1984; (République de) Haute Volta (Upper Volta)"),
New JednoEntry("RU", "Burundi", "1960", "", "", "", "Belgian territory of Ruanda-Urundi. Unofficially using BU on their plates."),
New JednoEntry("BU", "Burundi", "", "", "", "", "nieoficjalny, bo oficjalny to RU"),
New JednoEntry("RCH", "Chile", "1930", "", "", "", "República de Chile"),
New JednoEntry("CHN ", "Chiny", "", "", "", "", ""),
New JednoEntry("HR", "Chorwacja", "1992", "", "SHS, Y, YU", "", "Hrvatska (Croatian). Formerly part of Yugoslavia. Immediately after Croatia's declaration of independence in 1991, it was common to see unofficial oval stickers with the letters 'CRO'. Despite the initial anticipation that Croatia's international vehicle registration code would be 'CRO', Croatia opted for 'HR' (Hrvatska) instead."),
New JednoEntry("NDH ", "Chorwacja", "1941", "1945", "", "Y, YU, HR", "Nesavisna Drzava Hrvatska"),
New JednoEntry("CY", "Cypr", "1932", "", "", "", ""),
New JednoEntry("TCH", "Czad", "1973", "", "", "", "Tchad (French)"),
New JednoEntry("CG ", "Czarnogóra", "", "2006", "", "MNE", ""),
New JednoEntry("MN", "Czarnogóra", "1913", "1918", "", "SHS, Y, YU, SCG, MNE, CG", " Montenegro; Independent nation until 1918. After that, part of the Kingdom of Serbs, Croats and Slovenes (Kraljevina Srba, Hrvata i Slovenaca – Serbo-Croatian), then part of Yugoslavia and then Serbia and Montenegro (Srbija i Crna Gora – Serbian). Independence restored in 2006."),
New JednoEntry("CZ", "Czech Republic", "1993", "", "CS", "", "Formerly Československo (Czechoslovakia)."),
New JednoEntry("CS", "Czechosłowacja", "1924", "1992", "", "CZ, SK", "PL: od 1922; Split into Czech Republic and Slovakia."),
New JednoEntry("DK", "Dania", "1914", "", "", "", ""),
New JednoEntry("CGO", "Demokratyczna Republika Konga", "1997", "", "CB, RCL, ZRE", "", "French: Congo Belge, République de Congo Léopoldville, Congo (Kinshasa), Zaïre, République Démocratique du Congo (French)"),
New JednoEntry("CGO", "Demokratyczna Republika Konga", "1961", "1972", "ZR", "", ""),
New JednoEntry("WD", "Dominika", "1954", "", "", "", "Windward Islands Dominica"),
New JednoEntry("DJI ", "Dżibuti", "", "", "", "", ""),
New JednoEntry("ET", "Egipt", "1927", "", "", "", ""),
New JednoEntry("EC", "Ekwador", "1962", "", "EQ", "", ""),
New JednoEntry("EQ", "Ekwador", "1952", "1962", "", "", ""),
New JednoEntry("ER", "Erytrea", "1993", "", "AOI", "", "Africa Orientale Italiana (Italian)."),
New JednoEntry("ERI", "Erytrea", "", "", "", "", ""),
New JednoEntry("EST", "Estonia", "1993", "", "EW, SU", "", "Eesti Vabariik (Estonian; old style Eesti Wabariik). "),
New JednoEntry("EW", "Estonia", "1919", "1940", "", "EST", "Eesti Vabariik (Estonian); PL: od 1930"),
New JednoEntry("EW", "Estonia", "1991", "1993", "", "EST", "Eesti Vabariik (Estonian)"),
New JednoEntry("SD", "Eswatini", "1935", "", "", "", "Formerly Swaziland"),
New JednoEntry("ETH", "Etiopia", "1964", "", "AOI − 1941", "", "Africa Orientale Italiana (Italian). "),
New JednoEntry("FJI", "Fidżi", "1971", "", "", "", ""),
New JednoEntry("PI ", "Filipiny", "1952", "1975", "", "RP", "Pilipinas"),
New JednoEntry("RP", "Filipiny", "1975", "", "", "", "Republika ng Pilipinas (Republic of the Philippines)"),
New JednoEntry("SF", "Finland", "1921", "1993", "", "FIN", "SF from 'Suomi – Finland' (the names of the country in its official languages, Finnish and Swedish)"),
New JednoEntry("FIN", "Finlandia", "1993", "", "SF", "", "Suomi / Finland (Finnish/Swedish). "),
New JednoEntry("F", "Francja", "1910", "", "", "", ""),
New JednoEntry("AEF ", "Francuska Afryka Równikowa", "", "", "", "", "Afrique Equatoriale Française"),
New JednoEntry("AOF", "Francuska Afryka Zachodnia", "", "", "", "", "Afrique Occidentale Française"),
New JednoEntry("F", "French India", "1924", "1977", "", "", ""),
New JednoEntry("G", "Gabon", "1974", "", "ALEF − 1960", "", "Afrique Équatoriale Française. Unofficially using RG on their license plates."),
New JednoEntry("WAG", "Gambia", "1932", "", "", "", "West Africa Gambia"),
New JednoEntry("DA", "Gdańsk", "1922", "1939", "", "D, PL", "Danzig; 39-45 D, 45- PL"),
New JednoEntry("DDR", "Niemiecka Republika Demokratyczna", "1974", "1990", "D", "D", "From 1974 (used D until 1974), Deutsche Demokratische Republik. "),
New JednoEntry("GH", "Ghana", "1959", "", "WAC − 1957", "", "West Africa Gold Coast − 1957. "),
New JednoEntry("GBZ", "Gibraltar", "1924", "", "GB 1911-1924", "", "(United Kingdom of) Great Britain & Northern Ireland – Gibraltar (Z was assigned because G was already used for Guernsey)"),
New JednoEntry("HV", "Górna Wolta", "1961", "1984", "", "BF", "(French: Haute-Volta), now Burkina Faso"),
New JednoEntry("RHV ", "Górna Wolta", "", "", "", "BF", "République Haute Volta, obecnie Burkina Faso: BF"),
New JednoEntry("GR", "Grecja", "1913", "", "", "", ""),
New JednoEntry("WG", "Grenada", "1932", "", "", "", "Windward Islands Grenada"),
New JednoEntry("GRO", "Grenlandia", "", "", "", "KN", "Grønland (Danish language) / Kalaallit Nunaat (Greenlandic language). Unofficial. The official code is DK."),
New JednoEntry("KN ", "Grenlandia", "", "", "", "", "Kalaallit Nunaat"),
New JednoEntry("GE", "Gruzja", "1992", "", "SU", "", "Formerly part of the Soviet Union. Older licence plates use 'GEO' instead of 'GE'. Also used by Equatorial-Guinea (Spanish: Guinea Ecuatorial). "),
New JednoEntry("GBG", "Guernsey", "1924", "", "GB 1914-1924", "", "(United Kingdom of) Great Britain & Northern Ireland – Guernsey"),
New JednoEntry("RG", "Guinea", "1972", "", "", "", "République de Guinée (French). Also used unofficially by Gabon."),
New JednoEntry("BRG ", "Gujana Brytyjska", "1954", "1972", "", "GUY", "obecne Gujana"),
New JednoEntry("GUY", "Guyana", "1972", "", "BRG", "", "Formerly British Guiana − 1966. "),
New JednoEntry("G", "Gwatemala", "1924", "1977", "", "", ""),
New JednoEntry("GCA", "Gwatemala", "1956", "", "G", "", "Guatemala, Central America"),
New JednoEntry("GUI", "Gwinea", "", "", "", "", ""),
New JednoEntry("GNB ", "Gwinea Bissau", "", "", "", "", ""),
New JednoEntry("GUB ", "Gwinea Bissau", "", "", "", "", ""),
New JednoEntry("GQ ", "Gwinea Równikowa", "", "", "", "", ""),
New JednoEntry("RH", "Haiti", "1952", "", "", "", "République d'Haïti"),
New JednoEntry("NL", "Holandia", "1910", "", "", "", ""),
New JednoEntry("IN ", "Holenderskie Indie Wschodnie", "1930", "1949", "", "RI", "obecnie Indonezja"),
New JednoEntry("IN ", "Indonezja", "1949", "1955", "", "RI", ""),
New JednoEntry("HN", "Honduras", "", "", "", "", "Unofficial: no other code found for Honduras."),
New JednoEntry("HK ", "Hongkong", "1932", "", "", "", ""),
New JednoEntry("IS", "Icelandia", "1936", "", "", "", ""),
New JednoEntry("IN", "Indies", "1924", "1977", "", "", ""),
New JednoEntry("IND", "Indies", "1947", "", "BI", "", ""),
New JednoEntry("RI", "Indonezja", "1955", "", "", "", "Republik Indonesia"),
New JednoEntry("IRQ", "Irak", "1930", "", "", "", ""),
New JednoEntry("IR", "Iran", "1936", "", "PR", "", ""),
New JednoEntry("IRL", "Irlandia", "1992", "", "GB, SE, EIR, IRL", "", "Formerly a part of the United Kingdom, Saorstát Éireann, Éire. "),
New JednoEntry("SE", "Irlandia", "1924", "1938", "", "EIR, IRL", "Part of the United Kingdom at the time of the 1909 convention. Initials stand for Irish Saorstát Éireann."),
New JednoEntry("EIR", "Irlandia (Éire)", "1938", "1992", "", "IRL", " Éire"),
New JednoEntry("IL", "Izrael", "1952", "", "", "", "'Israel' is also written on the plate in Hebrew (ישראל) and Arabic (إسرائيل). "),
New JednoEntry("JA", "Jamajka", "1932", "", "", "", ""),
New JednoEntry("J", "Japonia", "1964", "", "", "", ""),
New JednoEntry("Y", "Jemen", "", "", "", "", ""),
New JednoEntry("YAR", "Jemen", "1960", "", "", "", "North Yemen formerly known as the Yemen Arab Republic."),
New JednoEntry("GBJ", "Jersey", "1924", "", "GB 1914-1924", "", "(United Kingdom of) Great Britain & Northern Ireland – Jersey"),
New JednoEntry("HKJ", "Jordania", "1966", "", "JOR", "", "Hashemite Kingdom of Jordan"),
New JednoEntry("JOR ", "Jordania", "1955", "1966", "", "HKJ", ""),
New JednoEntry("Y", "Jugosławia", "1936", "1953", "", "YU", "Yemen started using Y afterwards"),
New JednoEntry("YU", "Jugosławia", "", "1992", "", "BIH, HR, NMK, MNE, RKS, SRB, SLO", "Now Bosnia and Herzegovina, Croatia, North Macedonia, Montenegro, Kosovo, Serbia, and Slovenia. MK for Macedonia was in use from 1993 until 2019. "),
New JednoEntry("K", "Kambodża", "1956", "", "", "", "Known as Kampuchea 1976–89. Formerly a territory of France. KH currently being used (Khmer) on driving licenses, "),
New JednoEntry("CAM", "Kamerun", "1952", "1972", "F, WAN", "", "Formerly a territory of France, plus a strip of territory from eastern Nigeria (WAN). Unofficially using CMR on their plates."),
New JednoEntry("RUC", "Kamerun", "1972", "1983", "", "CAM", "République Unie du Caméroun"),
New JednoEntry("CAM ", "Kamerun", "1984", "", "RUC", "", ""),
New JednoEntry("CA", "Kanada", "", "1956", "", "CDN", ""),
New JednoEntry("CDN", "Kanada", "1956", "", "CA", "", "CDN for 'Canada Dominion'"),
New JednoEntry("Q", "Katar", "1972", "", "", "", ""),
New JednoEntry("QA", "Katar", "1972", "", "", "", "(wg polskiej Wiki)"),
New JednoEntry("KZ", "Kazahstan", "1992", "", "SU", "", "Formerly part of the Soviet Union. "),
New JednoEntry("EAK", "Kenia", "1938", "", "", "", "East Africa Kenya"),
New JednoEntry("KG", "Kirgistan", "2016", "", "SU, KS", "", "Formerly part of the Soviet Union. The Kyrgyz government notified the change from 'KS' to 'KG', which featured on the new car registration plates from March 2016, in August that year to the UN Secretary-General.[11] Additionally, most vehicles use 'KGZ' oval stickers instead of 'KS'. "),
New JednoEntry("KS", "Kirgistan", "1992", "2016", "SU", "KG", "Ratified by the United Nations as KG in March 2016."),
New JednoEntry("KIR ", "Kiribati", "", "", "", "", ""),
New JednoEntry("CO", "Kolumbia", "1952", "", "", "", ""),
New JednoEntry("COM ", "Komory", "", "", "", "", ""),
New JednoEntry("RCB", "Kongo", "1962", "", "", "", "République du Congo Brazzaville (French). Unofficially using RC on current plates."),
New JednoEntry("CB ", "Kongo Belgijskie", "1931", "1961", "", "", ""),
New JednoEntry("KP ", "Korea Północna", "", "", "", "", ""),
New JednoEntry("ROK", "Korea Południowa", "1971", "", "", "", "Republic of Korea. Unofficially using KOR on their plates."),
New JednoEntry("CD", "Korpus dyplomatyczny", "", "", "", "", ""),
New JednoEntry("CC", "Korpus konsularny", "", "", "", "", ""),
New JednoEntry("RKS", "Kosowo", "2010", "", "SHS, Y, YU, SCG, SRB", "", "Republika e Kosoves/Republika Kosovo"),
New JednoEntry("CR", "Kostaryka", "1956", "", "", "", ""),
New JednoEntry("SHS", "Królestwo Serbów, Chorwatów i Słoweńców", "1929", "1936", "", "Y, YU", "Kraljevina Srba, Hrvata i Slovenaca – Serbo-Croatian. Kingdom changed its name to Yugoslavia"),
New JednoEntry("C", "Kuba", "1930", "1977", "", "", ""),
New JednoEntry("CU", "Kuba", "1930", "", "", "", ""),
New JednoEntry("IRQ KR", "Kurdistan", "1991", "", "", "", ""),
New JednoEntry("KWT", "Kuwejt", "1954", "", "", "", ""),
New JednoEntry("LAO", "Laos", "1959", "", "F – 1949", "", "Formerly a territory of France (French Indochina)."),
New JednoEntry("LMK ", "Lemkovyna", "1918", "", "", "", "Lemkivshchyna; Ruska Ludowa Republika Łemków"),
New JednoEntry("LS", "Lesotho", "1967", "", "BL", "", "Basutoland − 1966."),
New JednoEntry("RL", "Liban", "1952", "", "", "", "République Libanaise"),
New JednoEntry("LB", "Liberia", "1967", "", "", "", ""),
New JednoEntry("LAR", "Libia", "1972", "", "I − 1949, LT", "", "Libyan Arab Republic, unused, unofficial LY used instead."),
New JednoEntry("LT ", "Libia", "1960", "1971", "", "LAR", ""),
New JednoEntry("FL", "Liechtenstein", "1923", "", "", "", "Fürstentum Liechtenstein (German: 'Principality of Liechtenstein')"),
New JednoEntry("LT", "Litwa", "1924", "1940", "", "SU", ""),
New JednoEntry("LT", "Litwa", "1992", "", "SU", "", ""),
New JednoEntry("LR", "Łotwa", "1927", "1940", "", "SU, LV", "Latvijas Republika (Latvian)"),
New JednoEntry("LR", "Łotwa", "1991", "1992", "SU", "LV", ""),
New JednoEntry("LV", "Łotwa", "1992", "", "LR,SU", "", "Latvijas Republika (Latvian). "),
New JednoEntry("L", "Luksembourg", "1911", "", "", "", ""),
New JednoEntry("MK", "Macedonia", "1993", "2019", "YU", "NMK", "Became North Macedonia in 2019. "),
New JednoEntry("NMK", "Macedonia Północna", "2019", "", "YU, MK", "", "Formerly part of Yugoslavia. Known as Republic of Macedonia until 2019. Mix of English North and Macedonian Makedonija."),
New JednoEntry("RM", "Madagaskar", "1962", "", "", "", "République de Madagascar"),
New JednoEntry("MO ", "Makau", "", "", "", "", ""),
New JednoEntry("MW", "Malawi", "1965", "", "EA,NP, RNY", "", "Formerly the Nyasaland Protectorate."),
New JednoEntry("MV", "Malediwy", "1965", "", "", "", ""),
New JednoEntry("MAL", "Malezja", "1967", "", "PRK, FM, PTM", "", "Formerly Perak, then Federated Malay States, then Persekutuan Tanah Melayu (Malay)"),
New JednoEntry("PTM ", "Malezja", "1958", "1967", "", "MAL", "Perseketuan Tanah Melayu"),
New JednoEntry("RMM", "Mali", "1962", "", "AOF", "", "République du Mali. Formerly part of French West Africa (Afrique Occidentale Française)"),
New JednoEntry("M", "Malta", "1966", "", "GBY 1924–66", "", ""),
New JednoEntry("GBY", "Malta", "1924", "1966", "", "M", "Changed after independence from UK"),
New JednoEntry("RIM", "Mauretania", "1964", "", "", "", "République islamique de Mauritanie"),
New JednoEntry("MS", "Mauritius", "1938", "", "", "", ""),
New JednoEntry("MEX", "Meksyk", "1952", "", "", "", ""),
New JednoEntry("MNS ", "Mikronezja", "", "", "", "", ""),
New JednoEntry("FSM ", "Mikronezja", "", "", "", "", "Federated States of Micronesia"),
New JednoEntry("MYA", "Mjanma", "1995", "", "BUR", "", "dawniej jako Burma: BUR)"),
New JednoEntry("MD", "Mołdawia", "1992", "", "SU", "", "Formerly part of the Soviet Union. "),
New JednoEntry("MC", "Monako", "1910", "", "", "", ""),
New JednoEntry("MGL", "Mongolia", "2002", "", "", "", "MNG displayed on current plates. Nevertheless, the new format includes MGL once again. PL: od 1997"),
New JednoEntry("F", "Morocco", "1924", "1977", "", "", ""),
New JednoEntry("MA", "Moroko", "1924", "", "", "", "Maroc (French). "),
New JednoEntry("MOC", "Mozambik", "1932", "1956", "MOC: 1932–56", "P", "Formerly part of Portugal. Moçambique (Portuguese)."),
New JednoEntry("MOC", "Mozambik", "1975", "", "P", "", "Formerly part of Portugal. Moçambique (Portuguese)."),
New JednoEntry("PMR ", "Naddniestrze", "1990", "", "", "", ""),
New JednoEntry("NAM", "Namibia", "1990", "", "SWA", "", "Formerly South West Africa; PL: od 1993"),
New JednoEntry("NAU", "Nauru", "1968", "", "", "", ""),
New JednoEntry("NEP", "Nepal", "1970", "", "", "", ""),
New JednoEntry("EAN ", "Niasaland (East Africa Niasaland, 1938–1935, obecnie Malawi)", "", "", "", "", ""),
New JednoEntry("D", "Niemcy", "1910", "", "", "", "Deutschland (German); also used until 1974 by  East Germany, which then used DDR until German reunification in 1990"),
New JednoEntry("RN", "Niger", "1977", "", "AOF", "", "République du Niger. Formerly part of French West Africa (Afrique Occidentale Française)"),
New JednoEntry("WAN", "Nigeria", "1937", "", "", "", "West Africa Nigeria"),
New JednoEntry("NGR", "Nigeria", "", "", "", "WAN", "oficjalnie WAN"),
New JednoEntry("NIC", "Nikaragua", "1952", "", "", "", ""),
New JednoEntry("N", "Norwegia", "1922", "", "", "", ""),
New JednoEntry("NZ", "Nowa Zelandia", "1958", "", "", "", ""),
New JednoEntry("OM", "Oman", "", "", "", "", ""),
New JednoEntry("PAK ", "Pakistan", "1947", "1986", "", "", ""),
New JednoEntry("PK", "Pakistan", "1986", "", "PAK", "", ""),
New JednoEntry("PAL ", "Palestyna", "", "", "", "", ""),
New JednoEntry("PA", "Panama", "1952", "", "", "", ""),
New JednoEntry("PY", "Panama", "1924", "1952", "", "PA", ""),
New JednoEntry("PNG", "Papua Nowa Gwinea", "1978", "", "", "", ""),
New JednoEntry("PA", "Paragwaj", "1924", "1952", "", "", "current code is PY"),
New JednoEntry("PY", "Paragwaj", "1952", "", "PA", "", ""),
New JednoEntry("PR", "Persia", "1933", "1936", "", "IR", "obecnie Iran"),
New JednoEntry("PE", "Peru", "1937", "", "", "", ""),
New JednoEntry("PL", "Poland", "1921", "", "", "", ""),
New JednoEntry("RNR", "Północna Rodezja", "1960", "1966", "", "Z", "obecnie Zambia"),
New JednoEntry("SAU ", "Południowa Afryka", "1933", "1936", "", "ZA", ""),
New JednoEntry("ZA", "Południowa Afryka", "1936", "", "", "", "Zuid-Afrika (from Dutch; in Afrikaans it is Suid-Afrika)."),
New JednoEntry("RSR", "Południowa Rodezja", "1965", "1979", "", "SR; ZW", "Now Zimbabwe; PL: 1960-1979"),
New JednoEntry("PRI ", "Portoryko", "", "", "", "", ""),
New JednoEntry("P", "Portugalia", "1910", "", "", "", "Unofficially used for Palestine in the West Bank and Gaza Strip"),
New JednoEntry("SP ", "Protektorat Somaliland", "1930", "1960", "", "", "Somalia"),
New JednoEntry("DOM", "Republika Dominikany", "1952", "", "", "", ""),
New JednoEntry("RCA", "Republika Środkowoafrykańska", "1962", "", "", "", "République Centrafricaine"),
New JednoEntry("CV ", "Republika Zielonego Przylądka (Cape Verde)", "", "", "", "", ""),
New JednoEntry("RNY", "Rhodesia-Nyasaland Fed.", "1963", "1963", "", "NP, NR, SR, MW", "Now Malawi, Zambia and Zimbabwe"),
New JednoEntry("R", "Rumunia", "1930", "1981", "", "RO", ""),
New JednoEntry("RM", "Rumunia", "1912", "1930", "", "R, RO", ""),
New JednoEntry("RO", "Rumunia", "1981", "", "RM, R", "", ""),
New JednoEntry("RUS", "Russia", "1992", "", "SU", "", "Formerly part of the Soviet Union."),
New JednoEntry("R", "Russian Empire", "1910", "1926", "", "SU, RUS", ""),
New JednoEntry("RWA", "Rwanda", "1964", "", "RU", "", "Formerly part of Ruanda-Urundi − 1962."),
New JednoEntry("SA", "Saar Territory (League of Nations mandate)", "1926", "1935", "", "D", "SA is again Germany's Saarland"),
New JednoEntry("WSA", "Sahara Zachodnia", "", "", "", "", "Western Sahara"),
New JednoEntry("KAN ", "Saint Kitts i Nevis", "", "", "", "", ""),
New JednoEntry("SCN", "Saint Kitts i Nevis", "1987", "", "", "", ""),
New JednoEntry("WL", "Saint Lucia", "1932", "", "", "", "Windward Islands Saint Lucia"),
New JednoEntry("WV", "Saint Vincent i Grenadyny", "1932", "", "", "", "Windward Islands Saint Vincent"),
New JednoEntry("ES", "Salwador", "1978", "", "", "", "El Salvador"),
New JednoEntry("WS", "Samoa", "1962", "", "", "", "Formerly Western Samoa (Samoa Zachodnie)"),
New JednoEntry("RSM", "San Marino", "1932", "", "", "", "Repubblica di San Marino"),
New JednoEntry("STP ", "Sao Tomé-et-Principe", "", "", "", "", "Sao Tomé-et-Principe"),
New JednoEntry("SN", "Senegal", "1962", "", "", "", ""),
New JednoEntry("SB", "Serbia", "1910", "1919", "", "SHS, Y, YU, SCG, SRB", "Serbia became part of Kingdom of Serbs, Croats and Slovenes"),
New JednoEntry("SRB", "Serbia", "2006", "", "SB,SHS, Y, YU, SCG", "", "Formerly part of Kingdom of Serbia (Kraljevina Srbija – Serbian), Kingdom of Serbs, Croats and Slovenes (Kraljevina Srba, Hrvata i Slovenaca – Serbo-Croatian), Yugoslavia (Jugoslavija – Serbo-Croatian), and Serbia and Montenegro (Srbija i Crna Gora – Serbian)."),
New JednoEntry("SCG", "Serbia i Czarnogóra", "2003", "2006", "YU", "MNE, SRB", "From Serbian name 'Srbija i Crna Gora'. Now Montenegro, "),
New JednoEntry("SY", "Seszele", "1938", "", "", "", ""),
New JednoEntry("SM", "Siam", "1924", "1977", "", "", ""),
New JednoEntry("WAL", "Sierra Leone", "1937", "", "", "", "West Africa Sierra Leone; on local licence plates SLE is used; PL: od 1932"),
New JednoEntry("SGP", "Singapur", "1952", "", "", "", ""),
New JednoEntry("SK", "Słowacja", "1993", "", "CS, SQ", "", "Formerly Československo (Czechoslovakia)."),
New JednoEntry("SQ", "Słowacja", "1939", "1945", "", "CS, SK", ""),
New JednoEntry("SLO", "Słowenia", "1992", "", "SHS, Y, YU", "", "Formerly part of the Kingdom of Serbs, Croats and Slovenes Kraljevina Srba, Hrvata i Slovenaca (Serbo-Croatian), then part of Yugoslavia."),
New JednoEntry("SO", "Somalia", "1974", "", "SP", "", "Formerly Somaliland Protectorate."),
New JednoEntry("CFS ", "Somaliland Francuski", "", "", "", "DJI", "Côte Française des Somalis, obecnie Dżibuti"),
New JednoEntry("SU", "Soviet Union", "1924", "1977", "R", "EST, LT, LV, BY, MD, UA, TJ, TM, GE, KZ, UZ, KS, AZ, AM, RUS", " Soviet Union"),
New JednoEntry("E", "Spain", "1910", "", "", "", ""),
New JednoEntry("CL", "Sri Lanka", "1961", "", "", "", "Formerly Ceylon. However, 'SL' is being used on current driver licenses; PL: od 1932"),
New JednoEntry("US", "Stany Zjednoczone", "1920", "1950", "", "USA", " United States of America"),
New JednoEntry("USA", "Stany Zjednoczone", "1952", "", "US", "", "Used on registration plates for US Forces in Germany from 1962 until 2020, US now used by US Forces Germany since 2020. 'U' is currently used for registration plates for US Forces in Portugal (Lajes, Azores)."),
New JednoEntry("SUD", "Sudan", "1963", "", "", "", ""),
New JednoEntry("SME", "Surinam", "1936", "", "", "", ""),
New JednoEntry("CH", "Switzerland", "1911", "", "", "", "Confœderatio Helvetica (Latin)"),
New JednoEntry("SYR", "Syria", "1952", "", "", "", ""),
New JednoEntry("LSA", "Syria and Lebanon", "1924", "1977", "", "", "French League of Nations mandate"),
New JednoEntry("SCO ", "Szkocja", "", "", "", "", ""),
New JednoEntry("S", "Szwecja", "1911", "", "", "", ""),
New JednoEntry("TJ", "Tadżykistan", "1992", "", "SU", "", "Formerly part of the Soviet Union, used code 'PT' for Республика Таджикистан on plates from 1993 to 2003."),
New JednoEntry("RC", "Taiwan", "1932", "", "", "", "Unofficially also used by car license plates in the Republic of Congo (République du Congo)."),
New JednoEntry("T", "Tajlandia", "1955", "", "SM", "", ""),
New JednoEntry("EAT", "Tanzania", "1938", "", "EAT, EAZ", "", "East Africa Tanzania; formerly East Africa Tanganyika and East Africa Zanzibar"),
New JednoEntry("TL ", "Timor Wschodni", "", "", "", "", "Timor Wschodni (Timor-Leste)"),
New JednoEntry("RT", "Togo", "", "1973", "", "TG", "République togolaise (French). Formerly French Togoland − 1960"),
New JednoEntry("TG", "Togo", "1973", "", "RT", "", "Formerly République Togolaise (French); PL od 1962"),
New JednoEntry("TO", "Tonga", "1995", "", "", "", ""),
New JednoEntry("TS", "Triest", "1947", "1954", "", "", "Territory Zone A (controlled by the United Kingdom and United States from 1947 to 1954 before given to Italy). Now in Italy, Croatia and Slovenia. Free Territory of Trieste"),
New JednoEntry("TT", "Trynidad i Tobago", "1964", "", "TD", "", ""),
New JednoEntry("TD ", "Trynidad i Tobago", "1938", "1964", "", "TT", ""),
New JednoEntry("TN", "Tunezja", "1957", "", "F", "", "Formerly a territory of France. Unofficial code TU is common."),
New JednoEntry("TR", "Turcja", "1923", "", "", "", ""),
New JednoEntry("TM", "Turkmenistan", "1992", "", "SU", "", "Formerly part of the Soviet Union."),
New JednoEntry("TUV ", "Tuvalu", "", "", "", "", ""),
New JednoEntry("EAU", "Uganda", "1938", "", "", "", "East Africa Uganda"),
New JednoEntry("UA", "Ukraine", "1992", "", "SU", "", "Formerly part of the Soviet Union. "),
New JednoEntry("GB", "United Kingdom", "1910", "2021", "", "UK", "Changed to UK to be inclusive of Northern Ireland (which is not part of Great Britain), though the previous GB did also apply to Northern Ireland. "),
New JednoEntry("UK", "United Kingdom", "2021", "", "GB", "", "From 28 September 2021 the United Kingdom of Great Britain and Northern Ireland changed its international vehicle registration code from 'GB' to 'UK'. (This does not affect territories for which the United Kingdom controls international relations outside Great Britain and Northern Ireland.)"),
New JednoEntry("UK", "United Kingdom of Great Britain and Ireland.", "1910", "1921", "", "GB", ""),
New JednoEntry("U", "Urugwaj", "1949", "1970", "", "ROU", ""),
New JednoEntry("UY", "Urugwaj", "2012", "", "ROU", "", ""),
New JednoEntry("ROU", "Urugway", "1979", "2012", "", "UY", "República Oriental del Uruguay (Spanish)"),
New JednoEntry("UZ", "Uzbekistan", "1992", "", "SU", "", "Formerly part of the Soviet Union."),
New JednoEntry("VAN", "Vanuatu", "", "", "", "", ""),
New JednoEntry("SCV ", "Watykan rządowe", "", "", "", "", "Status Civitatis Vaticanae"),
New JednoEntry("V", "Watykan", "1931", "", "", "", "CV (Italian: Città del Vaticano) is used as a prefix on the licence plate number itself. The prefix used on official and government vehicles is SCV"),
New JednoEntry("H", "Węgry", "1910", "", "", "", ""),
New JednoEntry("YV", "Wenezuela", "1955", "", "", "", ""),
New JednoEntry("VN", "Wietnam", "1953", "", "", "", ""),
New JednoEntry("I", "Włochy", "1910", "", "", "", ""),
New JednoEntry("CI", "Wybrzeże kości słoniowej", "1961", "", "F", "", "Formerly a territory of France; Ivory Coast (Côte d'Ivoire)"),
New JednoEntry("GBM", "Wyspa Man", "1932", "", "", "", "(United Kingdom of) Great Britain & Northern Ireland – Isle of Man"),
New JednoEntry("AX ", "Wyspy Alandzkie", "2002", "", "", "", ""),
New JednoEntry("MH", "Wyspy Marshalla", "", "", "", "", ""),
New JednoEntry("MIS ", "Wyspy Marshalla", "", "", "", "", ""),
New JednoEntry("FO", "Wyspy owcze", "1996", "", "FR", "", "Føroyar."),
New JednoEntry("FR", "Wyspy owcze", "1976", "1996", "", "FO", "Føroyar (Faroese)"),
New JednoEntry("SOL", "Wyspy Salomona", "", "", "", "", ""),
New JednoEntry("SLB ", "Wyspy Salomona", "", "", "", "", ""),
New JednoEntry("WB", "Zachodni Brzeg", "", "", "", "", "West Bank"),
New JednoEntry("ZR", "Zair", "1973", "1980", "", "ZRE, CGO", ""),
New JednoEntry("ZRE", "Zair", "1980", "1997", "ZR", "CGO", "Now the Democratic Republic of the Congo"),
New JednoEntry("Z", "Zambia", "1964", "", "RNR", "", "Formerly Northern Rhodesia. However, 'ZM' is used on current driving licences; PL od 1966"),
New JednoEntry("EAZ", "Zanzibar", "1964", "", "", "", "East Africa Zanzibar"),
New JednoEntry("ZW", "Zimbabwe", "1980", "", "SR, RSR", "", "Formerly Southern Rhodesia until 1965, Rhodesia unrecognised until 1980; PL: od 1977"),
New JednoEntry("UAE", "Zjednoczone Emiraty Arabskie", "1971", "", "", "", " United Arab Emirates"),
New JednoEntry("WAC", "Złote Wybrzeże", "1932", "1959", "", "GH", "West Africa Gold Coast")
        }

    Public Shared _ShowHistory As Boolean
    Public Shared _ShowDetails As Boolean
End Class


Public Class KonwersjaVisibilityHist
    Inherits ValueConverterOneWaySimple

    Protected Overrides Function Convert(value As Object) As Object
        Return If(RejSwiat._ShowHistory, Visibility.Visible, Visibility.Collapsed)
    End Function
End Class

Public Class KonwersjaVisibilityDet
    Inherits ValueConverterOneWaySimple

    Protected Overrides Function Convert(value As Object) As Object
        Return If(RejSwiat._ShowDetails, Visibility.Visible, Visibility.Collapsed)
    End Function
End Class