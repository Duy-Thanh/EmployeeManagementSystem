#include <crypto.h>

typedef struct {
	struct AES_ctx *ctx;
} AES_Structure, *PAES_Structure;

PAES_Structure aes_structure;

void ADDCALL Init() {
	aes_structure = (AES_Structure *)malloc(sizeof(AES_Structure));
	aes_structure->ctx = (struct AES_ctx *)malloc(sizeof(struct AES_ctx));
}

int ADDCALL IsInitialized() { // 0 - no error; 1 - error
	if (aes_structure == NULL) return 1;
	else {
		if (aes_structure->ctx == NULL) return 1;
		else return 0;
	}	
}

void ADDCALL generate_random_iv(uint8_t *iv, int len) {
	for (int i = 0; i < len; i++) {
		iv[i] = rand() % 256;
	}
}

void ADDCALL generate_random_key(uint8_t *key, int len) {
	for (int i = 0; i < len; i++) {
		key[i] = rand() % 512;
	}
}

uint8_t* ADDCALL encrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv) {
	AES_init_ctx_iv(aes_structure->ctx, key, iv);
	AES_CTR_xcrypt_buffer(aes_structure->ctx, in, len);

	uint8_t *out = in;

	return out;
}

uint8_t* ADDCALL decrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv) {
	AES_init_ctx_iv(aes_structure->ctx, key, iv);
	AES_CTR_xcrypt_buffer(aes_structure->ctx, key, iv);

	uint8_t *out = in;

	return out;
}

void ADDCALL Close() {
	if (aes_structure != NULL) {
		if (aes_structure->ctx != NULL) {
			free(aes_structure->ctx);
		}

		free(aes_structure);
	}
}
