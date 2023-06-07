<template>
    <div>

    </div>
</template>
  
<script>
import { SecretClient } from '@azure/keyvault-secrets'
import { DefaultAzureCredential } from '@azure/identity';
export default {
    name: 'PlayerComponent',
    data() {
        return {

        };
    },
    mounted: async function () {
        // Create a secret client using the DefaultAzureCredential
        const credential = new DefaultAzureCredential();

        const url = `https://playsoftvault.vault.azure.net/`;
        const client = new SecretClient(url, credential);

        // Get a secret by name
        const secretName = "your-secret-name";
        const secret = await client.getSecret(secretName);

        // Use the secret value
        console.log(secret.value);

    },
    methods: {

    }
}
</script>
  
<style></style>