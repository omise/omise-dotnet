#!/usr/bin/make

# Configuration
#
# To change VERSION, Update AssemblyInfo.cs file and rebuild.
CONFIG := Debug
VERSION = $(shell \
	monodis --assembly $(DLL_FILE) | \
	grep 'Version' | \
	cut -d":" -f 2 | \
	tr -d " ")

# Commands aliases
XBUILD := xbuild /property:Configuration=Release
NUGET  := mono .nuget/Nuget.exe

# Files
SRC_FILES      := $(wildcard Omise.Net/**.cs)
TEST_SRC_FILES := $(wildcard Omise.Net.NUnit.Test/**.cs)

DLL_FILE        := Omise.Net/bin/$(CONFIG)/Omise.Net.dll
TEST_DLL_FILE   := Omise.Net.NUnit.Test/bin/$(CONFIG)/Omise.Net.NUnit.Test.dll
NUGET_SPEC_FILE := Omise.Net.nuspec
NUGET_PKG_FILE  := Omise.Net.$(VERSION).nupkg

# Targets

# Runs (and builds) tests by default.
default: test

# Builds DLL files.
build: $(DLL_FILE) $(TEST_DLL_FILE)
$(DLL_FILE) $(TEST_DLL_FILE): $(SRC_FILES)
	$(XBUILD)

# Clean
.PHONY: clean
clean:
	$(XBUILD) /t:clean
	rm -v *.nupkg || true

# Test with NUnit
.PHONY: test
test: $(TEST_DLL_FILE)
ifeq ($(strip $(TEST)),)
	nunit-console $(TEST_DLL_FILE)
else
	nunit-console $(TEST_DLL_FILE) -run=$(TEST)
endif

# Create Nuget packages.
package: $(NUGET_PKG_FILE)
$(NUGET_PKG_FILE): $(DLL_FILE)
ifneq ($(CONFIG),Release)
	@echo \`package\` target requires CONFIG=Release
	@exit 1

else
	sed -i".bak" -e "s#<version>.*</version>#<version>$(VERSION)</version>#g" Omise.Net.nuspec
	$(NUGET) pack $(NUGET_SPEC_FILE)
endif
	

