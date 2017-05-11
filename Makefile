#!/usr/bin/make

# Configuration
#
# To change VERSION, Update AssemblyInfo.cs file and rebuild.
CONFIG   := Debug
PLATFORM := netstandard1.2

OMISE_CSPROJ      := Omise/Omise.csproj
SRC_FILES         := $(wildcard Omise/**.cs)
OMISE_TEST_CSPROJ := Omise.Tests/Omise.Tests.csproj
SRC_TEST_FILES    := $(wildcard Omise.Tests/**.cs)
OMISE_DLL         := Omise/bin/$(CONFIG)/$(PLATFORM)/Omise.dll
OMISE_TEST_DLL    := Omise.Tests/bin/$(CONFIG)/Omise.Tests.dll

MONO    := mono
MSBUILD := msbuild /p:Configuration=$(CONFIG)
NUNIT   := $(MONO) packages/NUnit.ConsoleRunner.3.6.1/tools/nunit3-console.exe

.PHONY: test

build: $(OMISE_DLL)
$(OMISE_DLL): $(OMISE_CSPROJ) $(SRC_FILES)
	$(MSBUILD) $(OMISE_CSPROJ)

build-test: $(OMISE_TEST_DLL) $(SRC_TEST_FILES)
$(OMISE_TEST_DLL): $(OMISE_TEST_CSPROJ)
	$(MSBUILD) $(OMISE_TEST_CSPROJ)

test: $(OMISE_TEST_DLL)
	$(NUNIT) --noresult --full $(OMISE_TEST_DLL) 
