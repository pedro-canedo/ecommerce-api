CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS Departamentos (
    Id uuid PRIMARY KEY DEFAULT gen_random_uuid (), Codigo CHAR(3) NOT NULL UNIQUE, Descricao VARCHAR(10) NOT NULL
);

CREATE TABLE IF NOT EXISTS Produtos (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid (), Codigo TEXT NOT NULL, Descricao TEXT NOT NULL, DepartamentoId UUID NOT NULL, Preco DECIMAL(10, 2) NOT NULL, Status BOOLEAN NOT NULL, is_deleted BOOLEAN DEFAULT FALSE, operation VARCHAR(10), operation_timestamp TIMESTAMPTZ DEFAULT NOW(), FOREIGN KEY (DepartamentoId) REFERENCES Departamentos (Id)
);

CREATE TABLE IF NOT EXISTS Auditoria_Produtos (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid (), ProdutoId UUID NOT NULL, Operation VARCHAR(10) NOT NULL, OperationTimestamp TIMESTAMPTZ DEFAULT NOW(), FOREIGN KEY (ProdutoId) REFERENCES Produtos (Id)
);


INSERT INTO
    Departamentos (Codigo, Descricao)
VALUES ('010', 'BEBIDAS'),
    ('020', 'CONGELADOS'),
    ('030', 'LATICINIOS'),
    ('040', 'VEGETAIS') ON CONFLICT (Codigo) DO NOTHING;
CREATE OR REPLACE FUNCTION fn_audit_produtos() RETURNS 
TRIGGER AS 
$$
BEGIN
	IF TG_OP = 'DELETE' THEN
	INSERT INTO
	    Auditoria_Produtos (ProdutoId, Operation)
	VALUES (OLD.Id, 'DELETE');
	ELSIF TG_OP = 'UPDATE' THEN
	INSERT INTO
	    Auditoria_Produtos (ProdutoId, Operation)
	VALUES (NEW.Id, 'UPDATE');
	ELSIF TG_OP = 'INSERT' THEN
	INSERT INTO
	    Auditoria_Produtos (ProdutoId, Operation)
	VALUES (NEW.Id, 'CREATE');
END
	IF;
	RETURN NULL;
END;
$$
LANGUAGE
plpgsql; 


CREATE TRIGGER trg_audit_produtos AFTER
INSERT
    OR
UPDATE
OR DELETE ON Produtos FOR EACH ROW
EXECUTE FUNCTION fn_audit_produtos ();