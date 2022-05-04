----------------------------------------------------------------------------------------------

DROP TRIGGER IF EXISTS trg_pacjnt_au;
CREATE OR ALTER TRIGGER trg_pacjnt_au ON pacjent
AFTER UPDATE
AS 
BEGIN
    SET NOCOUNT ON;
	UPDATE
	  pacjent
	SET
	  wpis_data_aktualizacji = GETDATE()
	FROM
	  inserted i
	WHERE
	  pacjent.id_pac = i.id_pac;
END;

----------------------------------------------------------------------------------------------

DROP TRIGGER IF EXISTS trg_wizyta_ii;
CREATE OR ALTER TRIGGER trg_wizyta_ii ON wizyta
INSTEAD OF INSERT
AS
BEGIN
    DECLARE
        @insertedIdPac INT,
        @zatrzaskIdPac INT;

    SELECT @insertedIdPac = i.id_pac FROM inserted i;
    SELECT @zatrzaskIdPac = ppz.id_pac_zatrzask FROM f_pobierz_pacjent_zatrzask(@insertedIdPac) ppz;

    if @zatrzaskIdPac IS NULL
    BEGIN
        INSERT INTO pacjent_zatrzask (
            id_pac,
            nazwisko,
            nazwisko_pan,
            imie,
            pesel,
            plec,
            nr_dokumentu,
            miasto,
            kod_poczt,
            ulica,
            nr_domu,
            nr_lokalu
        )
        SELECT
            p.id_pac,
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
            p.nr_lokalu
        FROM
            pacjent p
        JOIN
            inserted i ON i.id_pac = p.id_pac;

        SELECT
            @zatrzaskIdPac = MAX(pz.id_pac_zatrzask)
        FROM
            pacjent_zatrzask pz
        JOIN
            inserted i ON pz.id_pac = i.id_pac;
    END;

    INSERT INTO wizyta (
        id_pac,
        id_pac_zatrzask,
        status,
        data_rezerwacji_wizyty,
        data_anulowania_wizyty,
        data_rozpoczecia_wizyty,
        data_zakonczenia_wizyty
    )
    SELECT
        id_pac,
        @zatrzaskIdPac,
        status,
        data_rezerwacji_wizyty,
        data_anulowania_wizyty,
        data_rozpoczecia_wizyty,
        data_zakonczenia_wizyty
    FROM
        inserted;
END;

----------------------------------------------------------------------------------------------