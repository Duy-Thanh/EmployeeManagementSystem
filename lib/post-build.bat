@echo off

echo.
echo.
echo Post-build script file for building cryptography helper for Employee Management System
echo Copyright (C) 2016 - 2024 Nguyen Duy Thanh, CyberDay Studios. All right reserved.
echo.

set ROOT_DIR=%~dp0

echo Root directory is set to %ROOT_DIR%

set BUILD_DIR=%ROOT_DIR%build

echo Build directory is set to %BUILD_DIR%

set BUILD_DLL_FILE=%BUILD_DIR%\crypt64.dll

echo DLL file is set to %BUILD_DLL_FILE%

IF EXIST "%BUILD_DLL_FILE%" (
    echo DLL file found in %BUILD_DLL_FILE%
) ELSE (
    echo File doesn't exists.
    exit /b
)

set PROJECT_NAME=StaffManagers
set PROJECT_DIR=..\%PROJECT_NAME%

echo Project directory is set to %PROJECT_DIR%

IF EXIST "%PROJECT_DIR%" (
    echo Project directory found at %PROJECT_DIR%
) ELSE (
    echo Project directory doesn't exists.
    exit /b
)

set BIN_DIRECTORY=%PROJECT_DIR%\bin\x64\Debug

echo Binary output of directory is set to %BIN_DIRECTORY%

IF EXIST "%BIN_DIRECTORY%" (
    echo Binary output of the project is found at %BIN_DIRECTORY%
    echo Copy operation will begin shortly

    copy %BUILD_DLL_FILE% %BIN_DIRECTORY%

    echo Verifying DLL file

    echo DLL file required to check %BIN_DIRECTORY%\crypt64.dll

    IF EXIST "%BIN_DIRECTORY%\crypt64.dll" (
        echo File copied. All done!
        exit /b
    ) ELSE (
        echo File didn't copied. Please try again
        exit /b
    )
) ELSE (
    echo Binary output of the project doesn't exists. Creating directory
    mkdir %BIN_DIRECTORY%

    IF EXIST "%BIN_DIRECTORY%" (
        echo Creating directory done at %BIN_DIRECTORY% done. Copy operation will begin shortly

        copy %BUILD_DLL_FILE% %BIN_DIRECTORY%

        echo Verifying DLL file

        set DLL_BIN_DIR_FILE=%BIN_DIRECTORY%\crypt64.dll

        IF EXIST "%DLL_BIN_DIR_FILE%" (
            echo File copied. All done!
            exit /b
        ) ELSE (
            echo File didn't copied. Please try again
            exit /b
        )
    ) ELSE (
        echo Failed to create directory at %BIN_DIRECTORY%
        exit /b
    )
)
