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
        f_zatrzask_pacjent(id_pac),
        status,
        data_rezerwacji_wizyty,
        data_anulowania_wizyty,
        data_rozpoczecia_wizyty,
        data_zakonczenia_wizyty
    FROM
        INSERTED;
END;

----------------------------------------------------------------------------------------------