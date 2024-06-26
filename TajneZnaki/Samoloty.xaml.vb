﻿
Imports pkar.DotNetExtensions

Public NotInheritable Class Samoloty
    Inherits Page

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ZmianaQuery(False)
    End Sub

    Private Sub uiSymbol_TextChanged(sender As Object, e As TextChangedEventArgs)
        ZmianaQuery(False)
    End Sub

    Private Sub uiKraj_TextChanged(sender As Object, e As TextChangedEventArgs)
        If uiKraj.Text.Length < 2 Then Return
        ZmianaQuery(True)
    End Sub

    Private Sub ZmianaQuery(sortByKraj As Boolean)

        Dim lista As List(Of JedenSamolot) = _slownik.Where(
        Function(x)
            If Not x.symbol.ContainsCI(uiSymbol.Text) Then Return False
            If Not x.kraj.ContainsCI(uiKraj.Text) Then Return False

            Return True
        End Function
        ).ToList

        If lista.Count > 50 Then
            uiMatchCount.Text = "Za dużo trafień"
            uiLista.ItemsSource = Nothing
        Else
            uiMatchCount.Text = lista.Count & " matches:"

            If sortByKraj Then
                uiLista.ItemsSource = From c In lista Order By c.kraj
            Else
                uiLista.ItemsSource = From c In lista Order By c.symbol
            End If

        End If
    End Sub




    Private Class JedenSamolot
        Public Property symbol As String
        Public Property kraj As String

        Public Sub New(symbol As String, kraj As String)
            Me.symbol = symbol
            Me.kraj = kraj
        End Sub
    End Class

    Private _slownik As JedenSamolot() =
        {
New JedenSamolot("YA", "Afghanistan"),
New JedenSamolot("ZA", "Albania"),
New JedenSamolot("7T-V", "Algeria cywilne"),
New JedenSamolot("7T-W", "Algeria militarne"),
New JedenSamolot("C3", "Andorra"),
New JedenSamolot("D2", "Angola"),
New JedenSamolot("VP-A", "Anguilla"),
New JedenSamolot("V2", "Antigua and Barbuda"),
New JedenSamolot("LV", "Argentina cywilne"),
New JedenSamolot("LV-X", "Argentina experymentalne"),
New JedenSamolot("LV-S", "Argentina LSA"),
New JedenSamolot("LV-U", "Argentina ultralight"),
New JedenSamolot("LQ", "Argentina government"),
New JedenSamolot("EK", "Armenia"),
New JedenSamolot("P4", "Aruba"),
New JedenSamolot("VH", "Australia"),
New JedenSamolot("OE", "Austria"),
New JedenSamolot("OE-B", "Austria oficjalne"),
New JedenSamolot("OE-L", "Austria scheduled"),
New JedenSamolot("OE-V", "Austria testowe"),
New JedenSamolot("OE-W", "Austria amfibie i wodne"),
New JedenSamolot("OE-X", "Austria"),
New JedenSamolot("OE-", "Austria gliders"),
New JedenSamolot("OE-9", "Austria motor gliders"),
New JedenSamolot("4K", "Azerbaijan"),
New JedenSamolot("C6", "Bahamas"),
New JedenSamolot("A9C", "Bahrain"),
New JedenSamolot("S2", "Bangladesh"),
New JedenSamolot("8P", "Barbados"),
New JedenSamolot("EW", "Belarus"),
New JedenSamolot("OO", "Belgium"),
New JedenSamolot("V3", "Belize"),
New JedenSamolot("TY", "Benin"),
New JedenSamolot("VP-B", "Bermuda"),
New JedenSamolot("VQ-B", "Bermuda"),
New JedenSamolot("A5", "Bhutan"),
New JedenSamolot("CP", "Bolivia"),
New JedenSamolot("E7", "Bosnia and Herzegovina"),
New JedenSamolot("A2", "Botswana"),
New JedenSamolot("PP", "Brazil"),
New JedenSamolot("PR", "Brazil experimental"),
New JedenSamolot("PS", "Brazil"),
New JedenSamolot("PT", "Brazil experimental"),
New JedenSamolot("PU", "Brazil microlights"),
New JedenSamolot("VP-L", "British Virgin Islands"),
New JedenSamolot("V8", "Brunei"),
New JedenSamolot("LZ", "Bulgaria"),
New JedenSamolot("XT", "Burkina Faso"),
New JedenSamolot("9U", "Burundi"),
New JedenSamolot("XU", "Cambodia"),
New JedenSamolot("TJ", "Cameroon"),
New JedenSamolot("C", "Canada"),
New JedenSamolot("C-I", "Canada ultralight"),
New JedenSamolot("D4", "Cape Verde"),
New JedenSamolot("VP-C", "Cayman Islands"),
New JedenSamolot("VQ-C", "Cayman Islands"),
New JedenSamolot("TL", "Central African Republic"),
New JedenSamolot("TT", "Chad"),
New JedenSamolot("CC", "Chile"),
New JedenSamolot("B", "China"),
New JedenSamolot("HJ", "Colombia"),
New JedenSamolot("D6", "Comoros"),
New JedenSamolot("TN", "Congo, Republic of"),
New JedenSamolot("9S", "Congo, Democratic Republic of"),
New JedenSamolot("E5", "Cook Islands"),
New JedenSamolot("TI", "Costa Rica"),
New JedenSamolot("9A", "Croatia"),
New JedenSamolot("9A-G", "Croatia gliders"),
New JedenSamolot("9A-H", "Croatia helicopters"),
New JedenSamolot("9A-O", "Croatia balloons"),
New JedenSamolot("9A-U", "Croatia ultralights"),
New JedenSamolot("CU-A", "Cuba rolnicze"),
New JedenSamolot("CU-C", "Cuba cargo"),
New JedenSamolot("CU-H", "Cuba helicopters"),
New JedenSamolot("CU-N", "Cuba private"),
New JedenSamolot("CI-T", "Cuba passenger"),
New JedenSamolot("CU-U", "Cuba ultralight"),
New JedenSamolot("5B-D", "Cyprus"),
New JedenSamolot("OK", "Czech Republic"),
New JedenSamolot("OK-0", "Czech Republic gliders"),
New JedenSamolot("OK-X", "Czech Republic unmanned"),
New JedenSamolot("OY", "Denmark"),
New JedenSamolot("OY-H", "Denmark helicopters"),
New JedenSamolot("J2", "Djibouti"),
New JedenSamolot("J7", "Dominica"),
New JedenSamolot("HI", "Dominican Republic"),
New JedenSamolot("4W", "East Timor"),
New JedenSamolot("HC", "Ecuador"),
New JedenSamolot("SU", "Egypt"),
New JedenSamolot("YS", "El Salvador"),
New JedenSamolot("3C", "Equatorial Guinea"),
New JedenSamolot("E3", "Eritrea"),
New JedenSamolot("ES", "Estonia"),
New JedenSamolot("3DC", "Eswatini"),
New JedenSamolot("ET", "Ethiopia"),
New JedenSamolot("VP-F", "Falkland Islands"),
New JedenSamolot("DQ", "Fiji"),
New JedenSamolot("OH", "Finland"),
New JedenSamolot("OH-H", "Finland helicopters"),
New JedenSamolot("OH-X", "Finland experimental"),
New JedenSamolot("OH-0", "Finland gliders"),
New JedenSamolot("OH-G", "Finland autogyros"),
New JedenSamolot("OH-U", "Finland ultralights"),
New JedenSamolot("F", "France"),
New JedenSamolot("F-C", "France gliders"),
New JedenSamolot("F-P", "France homebuild"),
New JedenSamolot("F-F", "France radiocontrolled"),
New JedenSamolot("F-J", "France ultralights"),
New JedenSamolot("F-Z", "France stateowned"),
New JedenSamolot("F-O", "French Guiana"),
New JedenSamolot("TR", "Gabon"),
New JedenSamolot("TR-K", "Gabon military"),
New JedenSamolot("C5", "Gambia"),
New JedenSamolot("4L", "Georgia"),
New JedenSamolot("D", "Germany"),
New JedenSamolot("9G", "Ghana"),
New JedenSamolot("VP-G", "Gibraltar"),
New JedenSamolot("SX", "Greece"),
New JedenSamolot("See Denmark", "Greenland"),
New JedenSamolot("J3", "Grenada"),
New JedenSamolot("TG", "Guatemala"),
New JedenSamolot("2", "Guernsey"),
New JedenSamolot("3X", "Guinea"),
New JedenSamolot("J5", "Guinea-Bissau"),
New JedenSamolot("8R", "Guyana"),
New JedenSamolot("HH", "Haiti"),
New JedenSamolot("HR", "Honduras"),
New JedenSamolot("B-H", "Hong Kong"),
New JedenSamolot("B-K", "Hong Kong"),
New JedenSamolot("B-L", "Hong Kong"),
New JedenSamolot("HA", "Hungary"),
New JedenSamolot("TF", "Iceland"),
New JedenSamolot("VT", "India"),
New JedenSamolot("PK", "Indonesia"),
New JedenSamolot("EP", "Iran"),
New JedenSamolot("YI", "Iraq"),
New JedenSamolot("EI", "Ireland"),
New JedenSamolot("EJ", "Ireland business"),
New JedenSamolot("M", "Isle of Man"),
New JedenSamolot("4X", "Israel"),
New JedenSamolot("4Z", "Israel"),
New JedenSamolot("I", "Italy"),
New JedenSamolot("TU", "Ivory Coast"),
New JedenSamolot("6Y", "Jamaica"),
New JedenSamolot("JA", "Japan"),
New JedenSamolot("JR", "Japan"),
New JedenSamolot("ZJ", "Jersey"),
New JedenSamolot("JY", "Jordan"),
New JedenSamolot("4YB", "Jordan and Iraq"),
New JedenSamolot("UP", "Kazakhstan"),
New JedenSamolot("5Y", "Kenya"),
New JedenSamolot("T3", "Kiribati"),
New JedenSamolot("Z6", "Kosovo"),
New JedenSamolot("9K", "Kuwait"),
New JedenSamolot("EX", "Kyrgyzstan"),
New JedenSamolot("RDPL", "Laos"),
New JedenSamolot("YL", "Latvia"),
New JedenSamolot("OD", "Lebanon"),
New JedenSamolot("7P", "Lesotho"),
New JedenSamolot("A8", "Liberia"),
New JedenSamolot("5A", "Libya"),
New JedenSamolot("HB", "Liechtenstein"),
New JedenSamolot("LY", "Lithuania"),
New JedenSamolot("LX", "Luxembourg"),
New JedenSamolot("B-M", "Macau"),
New JedenSamolot("5R", "Madagascar"),
New JedenSamolot("7Q", "Malawi"),
New JedenSamolot("9M", "Malaysia"),
New JedenSamolot("8Q", "Maldives"),
New JedenSamolot("TZ", "Mali"),
New JedenSamolot("9H", "Malta"),
New JedenSamolot("V7", "Marshall Islands"),
New JedenSamolot("F-O", "Martinique"),
New JedenSamolot("5T", "Mauritania"),
New JedenSamolot("3B", "Mauritius"),
New JedenSamolot("XA", "Mexico"),
New JedenSamolot("XB", "Mexico"),
New JedenSamolot("XC", "Mexico"),
New JedenSamolot("V6", "Micronesia"),
New JedenSamolot("ER", "Moldova"),
New JedenSamolot("3A-M", "Monaco"),
New JedenSamolot("JU", "Mongolia"),
New JedenSamolot("4O", "Montenegro"),
New JedenSamolot("VP-M", "Montserrat"),
New JedenSamolot("CN", "Morocco"),
New JedenSamolot("C9", "Mozambique"),
New JedenSamolot("XY", "Myanmar"),
New JedenSamolot("XZ", "Myanmar"),
New JedenSamolot("V5", "Namibia"),
New JedenSamolot("C2", "Nauru"),
New JedenSamolot("9N", "Nepal"),
New JedenSamolot("PH", "Netherlands"),
New JedenSamolot("PJ", "Netherlands Antilles"),
New JedenSamolot("ZK", "New Zealand"),
New JedenSamolot("ZL", "New Zealand"),
New JedenSamolot("ZM", "New Zealand"),
New JedenSamolot("YN", "Nicaragua"),
New JedenSamolot("5U", "Niger"),
New JedenSamolot("5N", "Nigeria"),
New JedenSamolot("P", "North Korea"),
New JedenSamolot("Z3", "North Macedonia"),
New JedenSamolot("LN", "Norway"),
New JedenSamolot("A4O", "Oman"),
New JedenSamolot("AP", "Pakistan"),
New JedenSamolot("SU-Y", "Palestine"),
New JedenSamolot("E4", "Palestine"),
New JedenSamolot("HP", "Panama"),
New JedenSamolot("P2", "Papua New Guinea"),
New JedenSamolot("ZP", "Paraguay"),
New JedenSamolot("OB", "Peru"),
New JedenSamolot("RP", "Philippines"),
New JedenSamolot("SP", "Poland"),
New JedenSamolot("SP-0", "Poland motor gliders"),
New JedenSamolot("SP-B", "Poland balloons"),
New JedenSamolot("SP-L", "Poland LOT"),
New JedenSamolot("SP-S", "Poland ultralights"),
New JedenSamolot("SP-X", "Poland autogyros"),
New JedenSamolot("SP-Y", "Poland experimental"),
New JedenSamolot("SN", "Poland government"),
New JedenSamolot("CR", "Portugal"),
New JedenSamolot("CS", "Portugal"),
New JedenSamolot("CS-B", "Portugal balloons"),
New JedenSamolot("CS-H", "Portugal helicopters"),
New JedenSamolot("CS-P", "Portugal gliders"),
New JedenSamolot("CS-T", "Portugal airliners"),
New JedenSamolot("CS-U", "Portugal ultralights"),
New JedenSamolot("CS-X", "Portugal experimental"),
New JedenSamolot("A7", "Qatar"),
New JedenSamolot("F-O", "Réunion"),
New JedenSamolot("YR", "Romania"),
New JedenSamolot("RA", "Russia"),
New JedenSamolot("RF", "Russia"),
New JedenSamolot("9XR", "Rwanda"),
New JedenSamolot("VQ-H", "Saint Helena/Ascension"),
New JedenSamolot("V4", "Saint Kitts and Nevis"),
New JedenSamolot("J6", "Saint Lucia"),
New JedenSamolot("J8", "Saint Vincent and the Grenadines"),
New JedenSamolot("5W", "Samoa"),
New JedenSamolot("T7", "San Marino"),
New JedenSamolot("S9", "São Tomé and Príncipe"),
New JedenSamolot("HZ", "Saudi Arabia"),
New JedenSamolot("6V", "Senegal"),
New JedenSamolot("6W", "Senegal"),
New JedenSamolot("YU", "Serbia"),
New JedenSamolot("S7", "Seychelles"),
New JedenSamolot("9L", "Sierra Leone"),
New JedenSamolot("9V", "Singapore"),
New JedenSamolot("OM", "Slovakia"),
New JedenSamolot("S5", "Slovenia"),
New JedenSamolot("H4", "Solomon Islands"),
New JedenSamolot("6O", "Somalia"),
New JedenSamolot("ZS", "South Africa"),
New JedenSamolot("ZT", "South Africa"),
New JedenSamolot("ZU", "South Africa"),
New JedenSamolot("HL", "South Korea"),
New JedenSamolot("Z8", "South Sudan"),
New JedenSamolot("EC", "Spain"),
New JedenSamolot("EM", "Spain"),
New JedenSamolot("4R", "Sri Lanka"),
New JedenSamolot("ST", "Sudan"),
New JedenSamolot("PZ", "Suriname"),
New JedenSamolot("SE", "Sweden"),
New JedenSamolot("HB", "Switzerland"),
New JedenSamolot("YK", "Syria"),
New JedenSamolot("B", "Taiwan"),
New JedenSamolot("EY", "Tajikistan"),
New JedenSamolot("5H", "Tanzania"),
New JedenSamolot("HS", "Thailand"),
New JedenSamolot("U", "Thailand ultralights"),
New JedenSamolot("5V", "Togo"),
New JedenSamolot("A3", "Tonga"),
New JedenSamolot("9Y", "Trinidad and Tobago"),
New JedenSamolot("TS", "Tunisia"),
New JedenSamolot("TC", "Turkey"),
New JedenSamolot("EZ", "Turkmenistan"),
New JedenSamolot("VQ-T", "Turks and Caicos"),
New JedenSamolot("T2", "Tuvalu"),
New JedenSamolot("5X", "Uganda"),
New JedenSamolot("UR", "Ukraine"),
New JedenSamolot("A6", "United Arab Emirates"),
New JedenSamolot("DU", "United Arab Emirates (Dubai)"),
New JedenSamolot("G", "United Kingdom"),
New JedenSamolot("4U", "United Nations[k]"),
New JedenSamolot("N", "United States"),
New JedenSamolot("CX", "Uruguay"),
New JedenSamolot("UK", "Uzbekistan"),
New JedenSamolot("YJ", "Vanuatu"),
New JedenSamolot("YV", "Venezuela"),
New JedenSamolot("VN", "Vietnam"),
New JedenSamolot("7O", "Yemen"),
New JedenSamolot("9J", "Zambia"),
New JedenSamolot("Z", "Zimbabwe")
        }

End Class
