#!/usr/bin/make

CONFIG := Debug

SRC_FILES      := $(wildcard Omise.Net/**.cs)
TEST_SRC_FILES := $(wildcard Omise.Net.NUnit.Test/**.cs)

DLL_FILE      := Omise.Net/bin/$(CONFIG)/Omise.Net.dll
TEST_DLL_FILE := Omise.Net.NUnit.Test/bin/$(CONFIG)/Omise.Net.NUnit.Test.dll

default: test

build: $(DLL_FILE) $(TEST_DLL_FILE)
$(DLL_FILE) $(TEST_DLL_FILE): $(SRC_FILES)
	xbuild /property:Configuration=$(CONFIG)

.PHONY: clean
clean:
	xbuild /property:Configuration=$(CONFIG) /t:clean

.PHONY: test
test: $(TEST_DLL_FILE)
ifeq ($(strip $(TEST)),)
	nunit-console $(TEST_DLL_FILE)
else
	nunit-console $(TEST_DLL_FILE) -run=$(TEST)
endif

