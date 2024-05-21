#pragma once

#include <stdio.h>
#include <memory.h>
#include <string.h>
#include <stdlib.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <tiny_aes.h>

// #define ADD_EXPORTS

#ifdef _WIN32
	#ifdef ADD_EXPORTS
		#define ADDAPI __declspec(dllexport)
	#else
		#define ADDAPI __declspec(dllimport)
	#endif

	// Define calling convention in one place, for convenience
	#define ADDCALL __cdecl
#else
	// Define with no-value on non-Windows OSes
	#define ADDAPI
	#define ADDCALL
#endif

// Make sure functions are exported with C linkage under C++ compiler
#ifdef __cplusplus
extern "C" {
#endif

ADDAPI size_t b64_encoded_size(size_t inlen);
ADDAPI char *b64_encode(const unsigned char *in, size_t len);
ADDAPI size_t b64_decoded_size(const char *in);
ADDAPI void b64_generate_decode_table();
ADDAPI int b64_isvalidchar(char c);
ADDAPI int b64_decode(const char *in, unsigned char *out, size_t outlen);

ADDAPI void Init();
ADDAPI int IsInitialized();
ADDAPI void generate_random_iv(uint8_t *iv, int len);
ADDAPI void generate_random_key(uint8_t *key, int len);
ADDAPI uint8_t *encrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv); 
ADDAPI uint8_t *decrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv);
ADDAPI void Close();

#ifdef _cplusplus
} // __cplusplus defined
#endif

