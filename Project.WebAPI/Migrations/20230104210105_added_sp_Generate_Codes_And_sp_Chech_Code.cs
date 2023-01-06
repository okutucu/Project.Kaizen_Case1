using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations
{
    public partial class added_sp_Generate_Codes_And_sp_Chech_Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                CREATE PROCEDURE [dbo].[sp_Generate_Codes]
                                    @length INT,
                                    @characters VARCHAR(256),
                                    @count INT
                                AS
                                BEGIN
                                    DECLARE @counter INT = 0
                                    WHILE @counter < @count
                                    BEGIN
                                        DECLARE @codeResult VARCHAR(256)
                                        SET @codeResult = ''                                    
                                        WHILE LEN(@codeResult) < @length
                                        BEGIN
                                           SET @codeResult = @codeResult + SUBSTRING(@characters, ABS(CHECKSUM(NEWID())) % LEN(@characters) + 1, 1)
                                        END
										DECLARE @isChecked BIT;
										EXEC [dbo].[sp_Check_Code]  @codeResult,  @length, @characters,  @isChecked OUTPUT;
										
										PRINT @isChecked
										
										IF @isChecked = 1
											BEGIN
												INSERT INTO Codes (Name , CreatedDate)
												VALUES (@codeResult , GETDATE())
												SET @counter = @counter + 1
											END   
                                    END
                                    
                                END
                                ");

            migrationBuilder.Sql($@"
                                CREATE PROCEDURE [dbo].[sp_Check_Code]
										@codeResult varchar(256),
										@length INT,
										@characters VARCHAR(256),
										@isValid BIT output
										AS
										BEGIN
										DECLARE @result BIT = 1
											IF LEN(@codeResult) <> @length
												BEGIN
													SET @result = 0
													SET @isValid = @result;
													RETURN @isValid
												END
											DECLARE @charIndex VARCHAR(8) = @codeResult
											WHILE LEN(@charIndex) > 0
											BEGIN
									
											DECLARE @ch VARCHAR(1) = LEFT(@charIndex, 1)
											IF CHARINDEX(@ch, @characters) = 0
												BEGIN
													SET @result = 0
													SET @isValid = @result;
													RETURN @isValid
												END
											SET @charIndex = SUBSTRING(@charIndex, 2, LEN(@charIndex))
											END
											
											DECLARE @isUniqe INT;
											SELECT  @isUniqe = (SELECT COUNT(*) FROM Codes WHERE Name = @codeResult);
											IF @isUniqe <> 0
										
												BEGIN
		
													SET @result = 0
													SET @isValid = @result;
													RETURN @isValid
												END	
											SET @isValid = @result;
											RETURN @isValid
										END
                                ");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC  [dbo].[sp_Generate_Codes]");
            migrationBuilder.Sql($@"DROP PROC  [dbo].[sp_Check_Code]");
        }
    }
}
