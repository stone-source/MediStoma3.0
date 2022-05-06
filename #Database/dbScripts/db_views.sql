----------------------------------------------------------------------------------------------

DROP VIEW IF EXISTS v_pacjent;
CREATE VIEW v_pacjent AS
SELECT
    p.id_pac,
    p.imie + ' ' + p.nazwisko AS imie_nazwisko,
    p.nazwisko_pan,
    p.pesel,
    CASE WHEN p.plec = 'K' THEN 'Kobieta' ELSE 'Mężczyzna' END AS plec,
    p.nr_dokumentu,
    CONCAT_WS (', ', 'ul. ' + CONCAT_WS('/', p.ulica + ' ' + p.nr_domu, CASE WHEN p.nr_lokalu = '' THEN NULL ELSE p.nr_lokalu END), p.kod_poczt, p.miasto) AS miejsce_zamieszkania,
    p.wpis_data_dodania,
    p.wpis_data_aktualizacji,
    p.wpis_czy_aktualny
FROM
  pacjent p;

----------------------------------------------------------------------------------------------

DROP VIEW IF EXISTS v_wizyta;
CREATE VIEW v_wizyta AS
SELECT
    p.nazwisko,
    p.nazwisko_pan,
    p.imie,
    p.pesel,
    p.plec,
    p.nr_dokumentu,
    p.miasto,
    p.kod_poczt,
    p.ulica,
    p.nr_domu,
    p.nr_lokalu,
    pz.nazwisko AS nazwisko_zatrzask,
    pz.nazwisko_pan AS nazwisko_pan_zatrzask,
    pz.imie AS imie_zatrzask,
    pz.pesel AS pesel_zatrzask,
    pz.plec AS plec_zatrzask,
    pz.nr_dokumentu AS nr_dokumentu_zatrzask,
    pz.miasto AS miasto_zatrzask,
    pz.kod_poczt AS kod_poczt_zatrzask,
    pz.ulica AS ulica_zatrzask,
    pz.nr_domu AS nr_domu_zatrzask,
    pz.nr_lokalu AS nr_lokalu_zatrzask,
    CASE
        WHEN w.status = 'Z' THEN 'Zarezerwowana'
        WHEN w.status = 'R' THEN 'W realizacji'
        WHEN w.status = 'A' THEN 'Anulowana'
        WHEN w.status = 'K' THEN 'Zakończona'
        ELSE 'Błąd'
    END AS status_wizyty,
    w.data_rezerwacji_wizyty,
    w.data_anulowania_wizyty,
    w.data_rozpoczecia_wizyty,
    w.data_zakonczenia_wizyty
FROM
    wizyta w
JOIN
    pacjent p ON w.id_pac = p.id_pac
JOIN
    pacjent_zatrzask pz ON w.id_pac_zatrzask = pz.id_pac_zatrzask;

  ----------------------------------------------------------------------------------------------