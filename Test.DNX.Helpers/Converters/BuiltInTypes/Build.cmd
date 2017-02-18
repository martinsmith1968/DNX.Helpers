@ECHO OFF

SETLOCAL EnableDelayedExpansion

CALL :BuildTemplate bool    Bool
CALL :BuildTemplate int     Int
CALL :BuildTemplate uint    UInt
CALL :BuildTemplate long    Long
CALL :BuildTemplate ulong   ULong
CALL :BuildTemplate byte    Byte
CALL :BuildTemplate sbyte   SByte
CALL :BuildTemplate short   Short
CALL :BuildTemplate ushort  UShort
CALL :BuildTemplate float   Float
CALL :BuildTemplate double  Double
CALL :BuildTemplate decimal Decimal

GOTO :EOF


:BuildTemplate
ECHO.%~1 (%~2)
SED -e "s/#type#/%~1/g" -e "s/#Name#/%~2/g" ConvertExtensionsTests.cs.template > Convert%~2ExtensionsTests.cs

GOTO :EOF
