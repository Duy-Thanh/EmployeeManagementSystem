CC=gcc
ROOT_DIR=$(shell cd)
ASM=$(ROOT_DIR)\bin\yasm.exe
SRC_DIR=$(ROOT_DIR)\src
INCLUDE_DIR=$(ROOT_DIR)\include
BUILD_DIR=$(ROOT_DIR)\build

BUILD_OUTPUT=$(BUILD_DIR)\crypt64.dll

SRC_FILE=$(SRC_DIR)\crypto.c		\
	 $(SRC_DIR)\aes_modes.c		\
	 $(SRC_DIR)\aeskey.c		\
	 $(SRC_DIR)\aestab.c		\
	 $(SRC_DIR)\aes_ni.c		\
	 $(SRC_DIR)\tiny_aes.c		\
	 $(SRC_DIR)\aes.c

TEST_SRC_FILE=$(SRC_DIR)\test_aes.c

SRC_ASM_FILE=$(SRC_DIR)\aes_amd64.asm

ASM_FLAGS=-f win64

ASM_OBJ=$(BUILD_DIR)\aes_amd64.o

RES_FILE=$(ROOT_DIR)\resource.rc
RESOURCE_OBJ=$(BUILD_DIR)\resources.o

CXXFLAGS=-I$(INCLUDE_DIR) -shared -s -Wall -mavx2 -O3 -o $(BUILD_OUTPUT)
LDFLAGS=-Wl,-Map=$(BUILD_DIR)\crypt64.map

.PHONY: all clean

all: $(BUILD_OUTPUT)
	
$(BUILD_OUTPUT): $(RES_FILE) $(SRC_ASM_FILE) $(SRC_FILE)
	rmdir /s /q $(BUILD_DIR)
	mkdir $(BUILD_DIR)
	windres -o $(RESOURCE_OBJ) $(RES_FILE)
	$(ASM) $(ASM_FLAGS) $(SRC_ASM_FILE) -o $(ASM_OBJ)
	$(CC) $(SRC_FILE) $(RESOURCE_OBJ) $(ASM_OBJ) $(CXXFLAGS) $(LDFLAGS)
	$(CC) $(TEST_SRC_FILE) $(SRC_FILE) $(ASM_OBJ) -I$(INCLUDE_DIR) -o $(BUILD_DIR)\test_aes.exe
	del /f /s /q $(BUILD_DIR)\*.o
	echo Running post-build script
	cmd.exe /c "$(ROOT_DIR)\post-build.bat"

clean:
	rmdir /s /q $(BUILD_DIR)
	mkdir $(BUILD_DIR)
