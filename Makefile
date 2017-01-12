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
XBUILD        := xbuild /property:Configuration=$(CONFIG)
MONO          := /usr/local/bin/mono
NUGET         := .nuget/NuGet.exe
NUNIT_CONSOLE := packages/NUnit.ConsoleRunner.3.5.0/tools/nunit3-console.exe

# Files
SRC_FILES      := $(wildcard Omise.Net/**.cs)
TEST_SRC_FILES := $(wildcard Omise.Net.NUnit.Test/**.cs)

DLL_FILE        := Omise/bin/$(CONFIG)/Omise.dll
TEST_DLL_FILE   := Omise.Tests/bin/$(CONFIG)/Omise.Tests.dll
NUGET_SPEC_FILE := Omise.nuspec
NUGET_PKG_FILE  := Omise.$(VERSION).nupkg

# Targets

# Runs (and builds) tests by default.
default: test

# Download dependencies.
deps: packages
packages:
	$(MONO) $(NUGET) restore

deps-test: $(NUNIT_CONSOLE)
$(NUNIT_CONSOLE):
	$(MONO) $(NUGET) install NUnit.Console -OutputDirectory packages

# Builds DLL files.
build: $(DLL_FILE) $(TEST_DLL_FILE)
$(DLL_FILE) $(TEST_DLL_FILE): $(SRC_FILES) $(TEST_SRC_FILES) packages
	$(XBUILD)

# Clean
.PHONY: clean
clean:
	$(XBUILD) /t:clean
	rm -v *.nupkg || true

# Test with NUnit
.PHONY: test
test: $(TEST_DLL_FILE) packages deps-test
ifeq ($(strip $(TEST)),)
	$(MONO) $(NUNIT_CONSOLE) $(TEST_DLL_FILE)
else
	$(MONO) $(NUNIT_CONSOLE) $(TEST_DLL_FILE) -run=$(TEST)
endif

# Create Nuget packages.
package: $(NUGET_PKG_FILE)
$(NUGET_PKG_FILE): $(DLL_FILE)
ifneq ($(CONFIG),Release)
	@echo \`package\` target requires CONFIG=Release
	@exit 1

else
	sed -i".bak" -e "s#<version>.*</version>#<version>$(VERSION)</version>#g" $(NUGET_SPEC_FILE)
	$(MONO) $(NUGET) pack $(NUGET_SPEC_FILE)
endif
	
