CREATE PROCEDURE StoredToListRecyclingBin AS
SELECT P.Id,P.Number,P.Name,P.Description,P.TypeId,P.WeaknessId,T.Id AS ElementTypeId,T.Description AS ElementTypeDescription, W.Id AS ElementWeaknessId,W.Description AS ElementWeaknessDescription,P.ImageUrl FROM POKEMONS AS P JOIN ELEMENTS AS T ON P.TypeId=T.Id JOIN ELEMENTS AS W ON P.WeaknessId=W.Id WHERE P.Active=0
