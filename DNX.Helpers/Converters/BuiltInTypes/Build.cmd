@ECHO OFF

SETLOCAL EnableDelayedExpansion


REM  :BuildTemplate C#-Type Descriptive-Name
CALL :BuildTemplate bool        Bool

CALL :BuildTemplate byte        Byte
CALL :BuildTemplate sbyte       SByte

CALL :BuildTemplate DateTime    DateTime

CALL :BuildTemplate short       Int16
CALL :BuildTemplate ushort      UInt16
CALL :BuildTemplate short       Short
CALL :BuildTemplate ushort      UShort

CALL :BuildTemplate int         Int32
CALL :BuildTemplate uint        UInt32
CALL :BuildTemplate int         Int
CALL :BuildTemplate uint        UInt

CALL :BuildTemplate long        Int64
CALL :BuildTemplate ulong       UInt64
CALL :BuildTemplate long        Long
CALL :BuildTemplate ulong       ULong

CALL :BuildTemplate float       Float
CALL :BuildTemplate float       Single
CALL :BuildTemplate double      Double
CALL :BuildTemplate decimal     Decimal

GOTO :EOF


:BuildTemplate
ECHO.%~1 (%~2)
SED -e "s/#type#/%~1/g" -e "s/#Name#/%~2/g" ConvertExtensions.cs.template > Convert%~2Extensions.cs

GOTO :EOF
