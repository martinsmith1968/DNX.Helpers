@ECHO OFF

SETLOCAL EnableDelayedExpansion

PUSHD "%~dp0"

REM  :BuildTemplate C#-Type Descriptive-Name
CALL :BuildTemplate byte        Byte
CALL :BuildTemplate sbyte       SByte

CALL :BuildTemplate DateTime    DateTime

CALL :BuildTemplate short       Int16
CALL :BuildTemplate ushort      UInt16

CALL :BuildTemplate int         Int32
CALL :BuildTemplate uint        UInt32

CALL :BuildTemplate long        Int64
CALL :BuildTemplate ulong       UInt64

CALL :BuildTemplate float       Float
CALL :BuildTemplate double      Double
CALL :BuildTemplate decimal     Decimal

GOTO :EOF


:BuildTemplate
ECHO.%~1 (%~2)
SED -e "s/#type#/%~1/g" -e "s/#Name#/%~2/g" MathExtensions.cs.template > Math%~2Extensions.cs

GOTO :EOF
