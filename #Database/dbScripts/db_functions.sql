----------------------------------------------------------------------------------------------

DROP FUNCTION IF EXISTS f_zatrzask_pacjent;
CREATE FUNCTION f_zatrzask_pacjent(@p_IdPac INT)  
RETURNS INT   
AS   
-- Returns the stock level for the product.  
BEGIN
    DECLARE
      @zatrzaskIdPac INT;  

    SELECT TOP 1
        @zatrzaskIdPac = pz.id_pac_zatrzask
    FROM
        t_pacjent_zatrzask pz
    JOIN
        t_pacjent p ON pz.id_pac = p.id_pac
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

    IF @zatrzaskIdPac IS NULL
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
            p_IdPac,
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
            t_pacjent p
        WHERE
            p.id_pac = p_IdPac;
        
        SELECT
            @zatrzaskIdPac = MAX(id_pac_zatrzask)
        FROM
            pacjent_zatrzask
        WHERE
            id_pac = @p_IdPac;
    END;

    RETURN @zatrzaskIdPac;
END; 

----------------------------------------------------------------------------------------------