migrate((db) => {
  const collection = new Collection({
    "id": "02m04h8oj0df37u",
    "created": "2022-12-20 07:35:07.375Z",
    "updated": "2022-12-20 07:35:07.375Z",
    "name": "recipies",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "os2boeyr",
        "name": "title",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": 5,
          "max": 50,
          "pattern": ""
        }
      },
      {
        "system": false,
        "id": "eoddg6qu",
        "name": "prepTime",
        "type": "number",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null
        }
      },
      {
        "system": false,
        "id": "2qbt1bsh",
        "name": "cookTime",
        "type": "number",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null
        }
      },
      {
        "system": false,
        "id": "xmqzvw3n",
        "name": "servings",
        "type": "number",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null
        }
      },
      {
        "system": false,
        "id": "gy1tbko1",
        "name": "ratings",
        "type": "relation",
        "required": false,
        "unique": false,
        "options": {
          "maxSelect": 1,
          "collectionId": "kfdh0zfadtsv8sf",
          "cascadeDelete": false
        }
      },
      {
        "system": false,
        "id": "tfg7nnic",
        "name": "ingredients",
        "type": "relation",
        "required": false,
        "unique": false,
        "options": {
          "maxSelect": 1,
          "collectionId": "uododknfckaqt1l",
          "cascadeDelete": false
        }
      },
      {
        "system": false,
        "id": "621suf8x",
        "name": "steps",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      },
      {
        "system": false,
        "id": "qgenxsml",
        "name": "imageUrl",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      }
    ],
    "listRule": null,
    "viewRule": null,
    "createRule": null,
    "updateRule": null,
    "deleteRule": null,
    "options": {}
  });

  return Dao(db).saveCollection(collection);
}, (db) => {
  const dao = new Dao(db);
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u");

  return dao.deleteCollection(collection);
})
