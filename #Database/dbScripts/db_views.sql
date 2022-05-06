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
  pacjent p