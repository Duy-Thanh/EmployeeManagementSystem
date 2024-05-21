#include "crypto.h" // Include the header file for your AES library

typedef struct {
	struct AES_ctx *ctx;
} AES_Struct, *PAES_Struct;

PAES_Struct AES;

void AES_Init() {
	AES = (AES_Struct *)malloc(sizeof(AES_Struct));
	AES->ctx = (struct AES_ctx *)malloc(sizeof(struct AES_ctx));
}

uint8_t* _encrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv) {
    AES_init_ctx_iv(AES->ctx, key, iv); 
    AES_CTR_xcrypt_buffer(AES->ctx, in, len); // Encrypt the data in the output buffer
    
    uint8_t *out = in;

    return out;
}

uint8_t* _decrypt_aes(uint8_t *in, size_t len, uint8_t *key, uint8_t *iv) {
    AES_init_ctx_iv(AES->ctx, key, iv);
    AES_CTR_xcrypt_buffer(AES->ctx, in, len); // Decrypt the data in the input buffer
    
    uint8_t *out = in;

    return out;
}

void generate_random_iv_test(uint8_t *iv) {
    // You need to implement a function to generate a random IV
    // Example code for generating a random IV (for demonstration purposes only)
    for (int i = 0; i < 16; i++) {
        iv[i] = rand() % 256; // Generate a random byte
    }
}

void generate_random_key_test(uint8_t *key) {
    for (int i = 0; i < 32; i++) {
        key[i] = rand() % 256; // Generate a random byte
    }
}

int main() {
    uint8_t key[32];
    uint8_t in[] = "my message";
    uint8_t iv[16];

    generate_random_iv_test(iv);
    generate_random_key_test(key);

    printf("AES TEST 0\n");
    size_t len = strlen((char *)in);
    printf("Length: %lu\n", strlen((char *)in));

    AES_Init();

    // Encrypt the input data
    uint8_t *encrypted_out = _encrypt_aes(in, len, key, iv);
    printf("ENC: %s\n", (char *)encrypted_out);

    // Decrypt the encrypted data
    uint8_t* decrypted_out = _decrypt_aes(encrypted_out, len, key, iv);
    printf("DEC: %s\n", (char *)decrypted_out);

    return 0;
}

