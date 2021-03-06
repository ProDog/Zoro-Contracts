﻿## NEO Non-Fungible Token Template

### What is a non-fungible token?
A non-fungible token (NFT) can be thought of like a property deed - each one is unique and carries some non-mutable information (e.g. the physical address of the property) although other information, such as the owner of the property can be changed. An NFT smart contract is useful to track ownership of real-world items, as well as in online gaming, allowing users to posess unique characters or items of a limited supply, that can be transferred between users without requiring the permission of the game owner.

The NFT proposal standard for the Neo Smart Economy is currently in development. This is a draft template example in Python showing how such a smart contract might be written. There is some overlap between NEP-5 (fungible) token functionality to make adoption easier by API writers.

### Smart Contract Operations
The operations of the NFT template contract are:

* allowance(token_id): returns approved third-party spender of a token
* approve(from, to, token_id): approve third party to spend a token
* balanceOf(owner): returns owner's current total tokens owned
* getTxInfo(txid): returns transfer's info
* mintToken(owner, properties): create a new NFT token
* modifyProperties(token_id, newProperties): modify token's read-write data
* name(): returns name of token
* ownerOf(token_id): returns owner of a token
* properties(token_id): returns a token's properties data
* supportedStandards(): returns NEP-10
* symbol(): returns token symbol
* totalSupply(): returns the total token supply deployed in the system
* transfer(from, to, token_id): transfers a token
* transferApp(from, to, token_id): transfers a token, the from must be calling contract hash
* transferFrom(from, to, token_id): transfers a token by authorized spender

#### Events
The events of the NFT template contract are:

* transfer(byte[] from , byte[] to, byte[] TokenId):transfers a token
* mintToken(byte[] address, byte[] TokenId): create a new NFT token
* modifyProperties(byte[] tokenId, byte[] newProperties)
### Properties

The properties is the basic information of NFT, including name, description and other fields. It has a uniform json format. When NFT is created, the json properties will be serialized into byte array and stored in NFT properties, which is deserialized into json when used externally, json properties like this:
```
{
    "name": "Identifies the asset to which this NFT represents" ,
    "description": "Describes the asset to which this NFT represents",
    "url": "https://www.xxx.cn/" 
}
```