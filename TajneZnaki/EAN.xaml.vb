Imports pkar.DotNetExtensions

Public NotInheritable Class EAN
    Inherits Page

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        ZmianaQuery(False)
    End Sub

    Private Sub uiSymbol_TextChanged(sender As Object, e As TextChangedEventArgs)
        ZmianaQuery(False)
    End Sub

    Private Sub uiKraj_TextChanged(sender As Object, e As TextChangedEventArgs)
        If uiKraj.Text.Length < 1 Then Return
        ZmianaQuery(True)
    End Sub

    Private Sub ZmianaQuery(sortByKraj As Boolean)

        Dim lista As List(Of JedenEAN)

        If uiSymbol.Text.Length > 1 Then

            lista = _slownik.Where(
        Function(x)
            If x.numOd > uiSymbol.Text Then Return False
            If x.numDo < uiSymbol.Text Then Return False
            If Not x.kraj.ContainsCI(uiKraj.Text) Then Return False

            Return True
        End Function
        ).ToList

        Else
            lista = _slownik.Where(Function(x) x.kraj.ContainsCI(uiKraj.Text)).ToList
        End If


        If lista.Count > 50 Then
            uiMatchCount.Text = "Za dużo trafień"
            uiLista.ItemsSource = Nothing
        Else
            uiMatchCount.Text = lista.Count & " matches:"

            If sortByKraj Then
                uiLista.ItemsSource = From c In lista Order By c.kraj
            Else
                uiLista.ItemsSource = From c In lista Order By c.numOd
            End If

        End If
    End Sub




    Private Class JedenEAN
        Public Property numOd As Integer
        Public Property numDo As Integer

        Public Property kraj As String

        Public Sub New(numOd As Integer, numDo As Integer, kraj As String)
            Me.numOd = numOd
            Me.numDo = numDo
            Me.kraj = kraj
        End Sub

        Public ReadOnly Property displayNum As String
            Get
                If numDo = numOd Then Return numDo
                Return $"{numOd}-{numDo}"
            End Get
        End Property

    End Class

    Private _slownik As JedenEAN() =
        {
New JedenEAN(1, 19, " UPC-A compatible -  United States"),
New JedenEAN(20, 29, " UPC-A compatible - Used to issue restricted circulation numbers within a geographic region"),
New JedenEAN(30, 39, " UPC-A compatible -  United States drugs (see United States National Drug Code)"),
New JedenEAN(40, 49, " UPC-A compatible - Used to issue restricted circulation numbers within a company"),
New JedenEAN(50, 59, " UPC-A compatible - GS1 US reserved for future use"),
New JedenEAN(60, 99, " UPC-A compatible -  United States"),
New JedenEAN(100, 139, " United States"),
New JedenEAN(200, 299, " Used to issue GS1 restricted circulation number within a geographic region"),
New JedenEAN(300, 379, " France and  Monaco"),
New JedenEAN(380, 380, " Bulgaria"),
New JedenEAN(383, 383, " Slovenia"),
New JedenEAN(385, 385, " Croatia"),
New JedenEAN(387, 387, " Bosnia and Herzegovina"),
New JedenEAN(389, 389, " Montenegro"),
New JedenEAN(390, 390, " Republic of Kosovo (EAN-imposed, no GS1 Member Organisation)"),
New JedenEAN(400, 440, " Germany (440 code inherited from former  East Germany upon reunification in 1990)"),
New JedenEAN(450, 459, " Japan (new Japanese Article Number range)"),
New JedenEAN(460, 469, " Russia (barcodes inherited from the  Soviet Union)"),
New JedenEAN(470, 470, " Kyrgyzstan"),
New JedenEAN(471, 471, " Taiwan"),
New JedenEAN(474, 474, " Estonia"),
New JedenEAN(475, 475, " Latvia"),
New JedenEAN(476, 476, " Azerbaijan"),
New JedenEAN(477, 477, " Lithuania"),
New JedenEAN(478, 478, " Uzbekistan"),
New JedenEAN(479, 479, " Sri Lanka"),
New JedenEAN(480, 480, " Philippines"),
New JedenEAN(481, 481, " Belarus"),
New JedenEAN(482, 482, " Ukraine"),
New JedenEAN(483, 483, " Turkmenistan"),
New JedenEAN(484, 484, " Moldova"),
New JedenEAN(485, 485, " Armenia"),
New JedenEAN(486, 486, " Georgia"),
New JedenEAN(487, 487, " Kazakhstan"),
New JedenEAN(488, 488, " Tajikistan"),
New JedenEAN(489, 489, " Hong Kong"),
New JedenEAN(490, 499, " Japan (original Japanese Article Number range)"),
New JedenEAN(500, 509, " United Kingdom"),
New JedenEAN(520, 521, " Greece"),
New JedenEAN(528, 528, " Lebanon"),
New JedenEAN(529, 529, " Cyprus"),
New JedenEAN(530, 530, " Albania"),
New JedenEAN(531, 531, " North Macedonia"),
New JedenEAN(533, 533, " Ayizo in August 2024"),
New JedenEAN(535, 535, " Malta"),
New JedenEAN(539, 539, " Ireland"),
New JedenEAN(540, 549, " Belgium and  Luxembourg"),
New JedenEAN(560, 560, " Portugal"),
New JedenEAN(569, 569, " Iceland"),
New JedenEAN(570, 579, " Denmark,  Faroe Islands and  Greenland"),
New JedenEAN(590, 590, " Poland"),
New JedenEAN(594, 594, " Romania"),
New JedenEAN(599, 599, " Hungary"),
New JedenEAN(600, 601, " South Africa"),
New JedenEAN(603, 603, " Ghana"),
New JedenEAN(604, 604, " Senegal"),
New JedenEAN(605, 605, " Democratic Republic of the Congo[3]"),
New JedenEAN(607, 607, " Oman"),
New JedenEAN(608, 608, " Bahrain"),
New JedenEAN(609, 609, " Mauritius"),
New JedenEAN(611, 611, " Morocco"),
New JedenEAN(612, 612, " Somalia[citation needed]"),
New JedenEAN(613, 613, " Algeria"),
New JedenEAN(615, 615, " Nigeria"),
New JedenEAN(616, 616, " Kenya"),
New JedenEAN(617, 617, " Cameroon"),
New JedenEAN(618, 618, " Ivory Coast"),
New JedenEAN(619, 619, " Tunisia"),
New JedenEAN(620, 620, " Tanzania"),
New JedenEAN(621, 621, " Syria"),
New JedenEAN(622, 622, " Egypt"),
New JedenEAN(623, 623, " Managed by GS1 Global Office for future MO (was  Brunei until May 2021)"),
New JedenEAN(624, 624, " Libya"),
New JedenEAN(625, 625, " Jordan"),
New JedenEAN(626, 626, " Iran"),
New JedenEAN(627, 627, " Kuwait"),
New JedenEAN(628, 628, " Saudi Arabia"),
New JedenEAN(629, 629, " United Arab Emirates"),
New JedenEAN(630, 630, " Qatar"),
New JedenEAN(631, 631, " Namibia[5]"),
New JedenEAN(640, 649, " Finland"),
New JedenEAN(680, 681, " China"),
New JedenEAN(690, 699, " China"),
New JedenEAN(700, 709, " Norway"),
New JedenEAN(729, 729, " Israel"),
New JedenEAN(730, 739, " Sweden"),
New JedenEAN(740, 740, " Guatemala"),
New JedenEAN(741, 741, " El Salvador"),
New JedenEAN(742, 742, " Honduras"),
New JedenEAN(743, 743, " Nicaragua"),
New JedenEAN(744, 744, " Costa Rica"),
New JedenEAN(745, 745, " Panama"),
New JedenEAN(746, 746, " Dominican Republic"),
New JedenEAN(750, 750, " Mexico"),
New JedenEAN(754, 755, " Canada"),
New JedenEAN(759, 759, " Venezuela"),
New JedenEAN(760, 769, " Switzerland and  Liechtenstein"),
New JedenEAN(770, 771, " Colombia"),
New JedenEAN(773, 773, " Uruguay"),
New JedenEAN(775, 775, " Peru"),
New JedenEAN(777, 777, " Bolivia"),
New JedenEAN(778, 779, " Argentina"),
New JedenEAN(780, 780, " Chile"),
New JedenEAN(784, 784, " Paraguay"),
New JedenEAN(786, 786, " Ecuador"),
New JedenEAN(789, 790, " Brazil"),
New JedenEAN(800, 839, " Italy,  San Marino and  Vatican City"),
New JedenEAN(840, 849, " Spain and  Andorra"),
New JedenEAN(850, 850, " Cuba"),
New JedenEAN(858, 858, " Slovakia"),
New JedenEAN(859, 859, " Czech Republic (barcode inherited from  Czechoslovakia)"),
New JedenEAN(860, 860, " Serbia (barcode inherited from  Yugoslavia and  Serbia and Montenegro)"),
New JedenEAN(865, 865, " Mongolia"),
New JedenEAN(867, 867, " North Korea"),
New JedenEAN(868, 869, " Turkey"),
New JedenEAN(870, 879, " Netherlands"),
New JedenEAN(880, 881, " South Korea"),
New JedenEAN(883, 883, " Myanmar"),
New JedenEAN(884, 884, " Cambodia"),
New JedenEAN(885, 885, " Thailand"),
New JedenEAN(888, 888, " Singapore"),
New JedenEAN(890, 890, " India[6]"),
New JedenEAN(893, 893, " Vietnam"),
New JedenEAN(894, 894, " Managed by GS1 Global Office for future MO ( Bangladesh?)"),
New JedenEAN(896, 896, " Pakistan"),
New JedenEAN(899, 899, " Indonesia"),
New JedenEAN(900, 919, " Austria"),
New JedenEAN(930, 939, " Australia"),
New JedenEAN(940, 949, " New Zealand"),
New JedenEAN(950, 950, " GS1 Global Office: Used to support territories & countries where no GS1 Member Organisation operates"),
New JedenEAN(951, 951, " Used to issue General Manager Numbers for the EPC General Identifier (GID) scheme as defined by the EPC Tag Data Standard"),
New JedenEAN(952, 952, " Used for demonstrations and examples of the GS1 system"),
New JedenEAN(955, 955, " Malaysia"),
New JedenEAN(958, 958, " Macau"),
New JedenEAN(960, 9624, " GS1 UK Office: GTIN-8 allocations"),
New JedenEAN(9625, 9626, " GS1 Poland Office: GTIN-8 allocations"),
New JedenEAN(9627, 969, " GS1 Global Office: GTIN-8 allocations"),
New JedenEAN(977, 977, " Serial publications (ISSN)"),
New JedenEAN(978, 979, " Bookland (ISBN) – 979-0 used for sheet music (ISMN-13, replaces deprecated ISMN M- numbers)"),
New JedenEAN(980, 980, " Refund receipts"),
New JedenEAN(981, 983, " GS1 coupon identification for common currency areas"),
New JedenEAN(990, 999, " GS1 coupon identification")
}

End Class
