CREATE PROCEDURE StoredToAdd
@Number INT,
@Name VARCHAR(50),
@Description VARCHAR(300),
@ImageUrl VARCHAR(350),
@TypeId INT,
@WeaknessId INT
as
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES (@Number,@Name,@Description,@ImageUrl,@TypeId,@WeaknessId,null,1)
