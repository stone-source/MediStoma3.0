DELETE FROM wizyta;
DELETE FROM pacjent_zatrzask;
DELETE FROM pacjent;

----------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS pacjent;
CREATE TABLE pacjent (
    id_pac INT IDENTITY(1,1) NOT NULL,
    nazwisko NVARCHAR(100) NOT NULL,
    nazwisko_pan NVARCHAR(50),
    imie NVARCHAR(100) NOT NULL,
    pesel VARCHAR(11) NOT NULL,
    plec CHAR(1) NOT NULL,
    nr_dokumentu VARCHAR(100) NOT NULL,
    miasto NVARCHAR(100) NOT NULL,
    kod_poczt VARCHAR(10) NOT NULL,
    ulica NVARCHAR(200) NOT NULL,
    nr_domu VARCHAR(10) NOT NULL,
    nr_lokalu VARCHAR(10),
    wpis_data_dodania DATETIME NOT NULL DEFAULT GETDATE(),
    wpis_data_aktualizacji DATETIME NOT NULL DEFAULT GETDATE(),
    wpis_czy_aktualny BIT NOT NULL DEFAULT 1,
    CONSTRAINT pk_id_pac PRIMARY KEY CLUSTERED (id_pac),
    CONSTRAINT ck_plec CHECK ((plec = 'K') or (plec = 'M'))
);

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = 'Płeć: K - Kobieta; M - Mężczyzna',
    @level0type = N'Schema', @level0name = 'dbo',
    @level1type = N'Table', @level1name = 'pacjent', 
    @level2type = N'Column', @level2name = 'plec';

----------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS pacjent_zatrzask;
CREATE TABLE pacjent_zatrzask (
    id_pac_zatrzask INT IDENTITY(1,1) NOT NULL,
    id_pac INT NOT NULL,
    nazwisko NVARCHAR(100) NOT NULL,
    nazwisko_pan NVARCHAR(50),
    imie NVARCHAR(100) NOT NULL,
    pesel VARCHAR(11) NOT NULL,
    plec CHAR(1) NOT NULL,
    nr_dokumentu VARCHAR(100) NOT NULL,
    miasto NVARCHAR(100) NOT NULL,
    kod_poczt VARCHAR(10) NOT NULL,
    ulica NVARCHAR(200) NOT NULL,
    nr_domu VARCHAR(10) NOT NULL,
    nr_lokalu VARCHAR(10),
    CONSTRAINT pk_id_pac_zatrzask PRIMARY KEY CLUSTERED (id_pac_zatrzask),
    CONSTRAINT fk_pacjent_zatrzask_pacjent FOREIGN KEY (id_pac) REFERENCES pacjent (id_pac)
);

----------------------------------------------------------------------------------------------

DROP TABLE IF EXISTS wizyta;
CREATE TABLE wizyta (
    id_wiz INT IDENTITY(1,1) NOT NULL,
    id_pac INT NOT NULL,
    id_pac_zatrzask INT NOT NULL,
    status CHAR(1) NOT NULL DEFAULT 'Z', 
    data_rezerwacji_wizyty DATETIME NOT NULL DEFAULT GETDATE(),
    data_anulowania_wizyty DATETIME,
    data_rozpoczecia_wizyty DATETIME,
    data_zakonczenia_wizyty DATETIME,
    CONSTRAINT pk_id_wiz PRIMARY KEY CLUSTERED (id_wiz),
    CONSTRAINT fk_wizyta_pacjent FOREIGN KEY (id_pac) REFERENCES pacjent (id_pac),
    CONSTRAINT fk_wizyta_pacjent_zatrzask FOREIGN KEY (id_pac_zatrzask) REFERENCES pacjent_zatrzask (id_pac_zatrzask),
    CONSTRAINT ck_status CHECK (status IN ('Z', 'R', 'A', 'K'))
);

EXEC sp_addextendedproperty 
    @name = N'MS_Description', @value = 'Wizyta: Z - Zarezerwowana; R - W realizacji; A - Anulowana; K - Zakończona',
    @level0type = N'Schema', @level0name = 'dbo',
    @level1type = N'Table', @level1name = 'wizyta', 
    @level2type = N'Column', @level2name = 'status';

----------------------------------------------------------------------------------------------