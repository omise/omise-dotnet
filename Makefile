#!/usr/bin/make

CONFIG    := Debug
PLATFORM  := netstandard2.0
FRAMEWORK := net462
MONO	  := mono
BUILD	  := dotnet build

OMISE_CSPROJ      := Omise/Omise.csproj
OMISE_TEST_CSPROJ := Omise.Tests/Omise.Tests.csproj
OMISE_EXAM_CSPROJ := Omise.Examples/Omise.Examples.csproj
OMISE_DLL         := Omise/bin/$(CONFIG)/$(PLATFORM)/Omise.dll
OMISE_TEST_DLL    := Omise.Tests/bin/$(CONFIG)/Omise.Tests.dll
OMISE_EXAMPLE_EXE := Omise.Examples/bin/$(CONFIG)/$(FRAMEWORK)/Omise.Examples.exe

SRC_FILES       := $(wildcard Omise/**/*.cs Omise/*.cs)
SRC_TEST_FILES  := $(wildcard Omise.Tests/**/*.cs Omise.Tests/*.cs)

.PHONY: test clean

default: build

build: $(OMISE_DLL)
$(OMISE_DLL): $(OMISE_CSPROJ) $(SRC_FILES)
	$(BUILD) $(OMISE_CSPROJ)

build-test: $(OMISE_TEST_DLL) $(SRC_TEST_FILES)
$(OMISE_TEST_DLL): $(OMISE_TEST_CSPROJ) $(SRC_TEST_FILES)
	$(BUILD) $(OMISE_TEST_CSPROJ)

build-example: $(OMISE_EXEAMPLE_EXE)
	$(BUILD) $(OMISE_EXAM_CSPROJ)

pack: $(OMISE_DLL)
	dotnet pack -c Release $(OMISE_CSPROJ)

clean:
	dotnet clean

test: $(SRC_FILES) $(SRC_TEST_FILES)
	dotnet test $(OMISE_TEST_CSPROJ)

run: build-example
	$(MONO) $(OMISE_EXAMPLE_EXE)