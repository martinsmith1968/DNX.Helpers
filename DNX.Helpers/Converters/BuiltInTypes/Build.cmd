@ECHO OFF

SETLOCAL EnableDelayedExpansion


REM  :BuildTemplate C#-Type Descriptive-Name
REM CALL :BuildTemplate bool        Bool
REM
REM CALL :BuildTemplate byte        Byte
REM CALL :BuildTemplate sbyte       SByte
REM
REM CALL :BuildTemplate DateTime    DateTime
REM
REM CALL :BuildTemplate short       Int16
REM CALL :BuildTemplate ushort      UInt16
REM CALL :BuildTemplate short       Short
REM CALL :BuildTemplate ushort      UShort
REM
REM CALL :BuildTemplate int         Int32
REM CALL :BuildTemplate uint        UInt32
REM CALL :BuildTemplate int         Int
REM CALL :BuildTemplate uint        UInt
REM
REM CALL :BuildTemplate long        Int64
REM CALL :BuildTemplate ulong       UInt64
REM CALL :BuildTemplate long        Long
REM CALL :BuildTemplate ulong       ULong
REM
REM CALL :BuildTemplate float       Float
REM CALL :BuildTemplate float       Single
REM CALL :BuildTemplate double      Double
REM CALL :BuildTemplate decimal     Decimal

GOTO :EOF


:BuildTemplate
ECHO.%~1 (%~2)
SED -e "s/#type#/%~1/g" -e "s/#Name#/%~2/g" ConvertExtensions.cs.template > Convert%~2Extensions.cs

GOTO :EOF
