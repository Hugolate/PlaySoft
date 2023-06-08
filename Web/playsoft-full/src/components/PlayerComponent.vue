<template>
    <div>

    </div>
</template>
  
<script>
import { SecretClient } from '@azure/keyvault-secrets'
import { InteractiveBrowserCredential } from '@azure/identity';
export default {
    name: 'PlayerComponent',
    data() {
        return {

        };
    },
    mounted: async function () {
        
        // Create a secret client using the DefaultAzureCredential
        const credential = new InteractiveBrowserCredential({
            clientId: "d949fc9c-ef24-4fae-b04c-caa2493d9ad7",
        });
        const url = `https://playsoftvault.vault.azure.net/`;
        const client = new SecretClient(url, credential);

        // Get a secret by name
        const secretName = "client-id";
        const secret = await client.getSecret(secretName);

        // Use the secret value
        console.log("AA", secret.value);

    },
    methods: {

    }
}
</script>
  
<style></style>