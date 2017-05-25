#!/usr/bin/make

CONFIG   := Debug
PLATFORM := netstandard1.2

OMISE_CSPROJ      := Omise/Omise.csproj
OMISE_TEST_CSPROJ := Omise.Tests/Omise.Tests.csproj
OMISE_DLL         := Omise/bin/$(CONFIG)/$(PLATFORM)/Omise.dll
OMISE_TEST_DLL    := Omise.Tests/bin/$(CONFIG)/Omise.Tests.dll

SRC_FILES       := $(wildcard Omise/**/*.cs Omise/*.cs)
SRC_TEST_FILES  := $(wildcard Omise.Tests/**/*.cs Omise.Tests/*.cs)
T4_FILES        := $(wildcard Omise/**/*.tt Omise/*.tt Omise.Tests/**/*.tt Omise.Tests/*.tt)
T4_OUTPUT_FILES := $(T4_FILES:.tt=.cs)

MONO    := mono
MSBUILD := msbuild /p:Configuration=$(CONFIG)
NUNIT   := $(MONO) packages/NUnit.ConsoleRunner.3.6.1/tools/nunit3-console.exe
T4      := $(MONO) /Applications/Visual\ Studio.app/Contents/Resources/lib/monodevelop/AddIns/MonoDevelop.TextTemplating/TextTransform.exe

.PHONY: test clean

t4: $(T4_OUTPUT_FILES)
%.cs: %.tt
	$(T4) -o="$@" "$<"

build: $(OMISE_DLL)
$(OMISE_DLL): $(OMISE_CSPROJ) $(SRC_FILES) $(T4_OUTPUT_FILES)
	$(MSBUILD) $(OMISE_CSPROJ)

build-test: $(OMISE_TEST_DLL) $(SRC_TEST_FILES)
$(OMISE_TEST_DLL): $(OMISE_TEST_CSPROJ) $(SRC_TEST_FILES) $(T4_OUTPUT_FILES)
	$(MSBUILD) $(OMISE_TEST_CSPROJ)

clean:
	$(MSBUILD) /target:Clean $(OMISE_CSPROJ)
clean-test:
	$(MSBUILD) /target:Clean $(OMISE_TEST_CSPROJ)

test: $(OMISE_TEST_DLL)
	$(NUNIT) --noresult --full $(OMISE_TEST_DLL) 
