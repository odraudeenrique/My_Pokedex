CREATE PROCEDURE StoredToUpdate 
@Number INT,
@Name VARCHAR(50),
@Description VARCHAR (300),
@ImageUrl VARCHAR(350),
@TypeId INT,
@WeaknessId INT,
@PokemonId INT
AS
UPDATE POKEMONS SET Number = @Number, Name = @Name, Description = @Description, ImageUrl = @ImageUrl, TypeId = @TypeId, WeaknessId = @WeaknessId WHERE Id = @PokemonId
