----------------------------------------------------------------------------------------------

DROP FUNCTION IF EXISTS f_pobierz_pacjent_zatrzask;
CREATE FUNCTION f_pobierz_pacjent_zatrzask (
    @p_IdPac INT
)
RETURNS TABLE
AS
RETURN
    SELECT TOP 1
        pz.id_pac_zatrzask
    FROM
        pacjent_zatrzask pz
    JOIN
        pacjent p ON pz.id_pac = p.id_pac
    WHERE
        pz.id_pac = @p_IdPac
        AND pz.nazwisko <> p.nazwisko
        AND pz.nazwisko_pan <> p.nazwisko_pan
        AND pz.imie <> p.imie
        AND pz.pesel <> p.pesel
        AND pz.plec <> p.plec
        AND pz.nr_dokumentu <> p.nr_dokumentu
        AND pz.miasto <> p.miasto
        AND pz.kod_poczt <> p.kod_poczt
        AND pz.ulica <> p.ulica
        AND pz.nr_domu <> p.nr_domu
        AND pz.nr_lokalu <> p.nr_lokalu;

----------------------------------------------------------------------------------------------