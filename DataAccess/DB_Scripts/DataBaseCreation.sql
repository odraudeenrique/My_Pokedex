USE MASTER
GO 
CREATE DATABASE MY_POKEDEX_DB
GO
USE My_POKEDEX_DB
GO
USE [My_POKEDEX_DB]
GO

/****** Object:  Table [dbo].[ELEMENTOS]    Script Date: 8/5/2021 9:48:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ELEMENTS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_ELEMENTS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [My_POKEDEX_DB]
GO

/****** Object:  Table [dbo].[POKEMONS]    Script Date: 8/5/2021 9:48:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[POKEMONS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](300) NULL,
	[ImageUrl] [varchar](350) NULL,
	[TypeId] [int] NULL,
	[WeaknessId] [int] NULL,
	[EvolutionId] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_POKEMONS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTS] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ELEMENTS] ([Id])
GO

ALTER TABLE [dbo].[POKEMONS] CHECK CONSTRAINT [FK_POKEMONS_ELEMENTS]
GO

ALTER TABLE [dbo].[POKEMONS]  WITH CHECK ADD  CONSTRAINT [FK_POKEMONS_ELEMENTS1] FOREIGN KEY([WeaknessId])
REFERENCES [dbo].[ELEMENTS] ([Id])
GO

insert into ELEMENTS values ('Grass')
insert into ELEMENTS values ('Fire')
insert into ELEMENTS values ('Water')
insert into ELEMENTS values ('Bug')
insert into ELEMENTS values ('Fairy')
insert into ELEMENTS values ('Ghost')
insert into ELEMENTS values ('Ground')
insert into ELEMENTS values ('Normal')
insert into ELEMENTS values ('Psychic')
insert into ELEMENTS values ('Steel')
insert into ELEMENTS values ('Dark')
insert into ELEMENTS values ('Electric')
insert into ELEMENTS values ('Fightning')
insert into ELEMENTS values ('Flying')
insert into ELEMENTS values ('Ice')
insert into ELEMENTS values ('Poison')
insert into ELEMENTS values ('Rock')


INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('1','Bulbasaur','For some time after its birth, it uses the nutrients that are packed into the seed on its back in order to grow.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/001.png',1,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('2','Ivysaur','The more sunlight Ivysaur bathes in, the more strength wells up within it, allowing the bud on its back to grow larger.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/002.png',1,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('3','Venusaur','While it basks in the sun, it can convert the light into energy. As a result, it is more powerful in the summertime.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/003.png',1,3,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('4','Charmander','The flame on its tail shows the strength of its life-force. If Charmander is weak, the flame also burns weakly.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/004.png',2,3,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('5','Charmeleon','When it swings its burning tail, the temperature around it rises higher and higher, tormenting its opponents.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/005.png',2,3,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('6','Charizard','If Charizard becomes truly angered, the flame at the tip of its tail burns in a light blue shade.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006.png',2,3,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('7','Squirtle','After birth, its back swells and hardens into a shell. It sprays a potent foam from its mouth.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/007.png',3,1,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('8','Wartortle','Wartortle’s long, furry tail is a symbol of longevity, so this Pokémon is quite popular among older people.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/008.png',3,1,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('9','Blastoise','It deliberately increases its body weight so it can withstand the recoil of the water jets it fires.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png',3,1,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('9','Blastoise','It deliberately increases its body weight so it can withstand the recoil of the water jets it fires.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/009.png',3,1,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('10','Caterpie','For protection, it releases a horrible stench from the antenna on its head to drive away enemies.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/010.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('11','Metapod','It is waiting for the moment to evolve. At this stage, it can only harden, so it remains motionless to avoid attack.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/011.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('12','Butterfree','It loves the nectar of flowers and can locate flower patches that have even tiny amounts of pollen.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/011.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('13','Weedle','Beware of the sharp stinger on its head. It hides in grass and bushes where it eats leaves.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/013.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('14','Kakuna','Able to move only slightly. When endangered, it may stick out its stinger and poison its enemy.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/014.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('15','Beedrill','It has three poisonous stingers on its forelegs and its tail. They are used to jab its enemy repeatedly.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/015.png',4,2,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('16','Pidgey','Very docile. If attacked, it will often kick up sand to protect itself rather than fight back.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/016.png',14,12,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('17','Pidgeotto','This Pokémon is full of vitality. It constantly flies around its large territory in search of prey.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/017.png',14,12,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('18','Pidgeot','This Pokémon flies at Mach 2 speed, seeking prey. Its large talons are feared as wicked weapons.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/018.png',14,12,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('19','Rattata','Will chew on anything with its fangs. If you see one, you can be certain that 40 more live in the area.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/019.png',8,14,null,1)
INSERT INTO POKEMONS(Number, Name, Description,ImageUrl,TypeId,WeaknessId,EvolutionId,Active) VALUES ('20','Raticate','Its hind feet are webbed. They act as flippers, so it can swim in rivers and hunt for prey.','https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/020.png',8,14,null,1)







