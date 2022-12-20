migrate((db) => {
  const collection = new Collection({
    "id": "3e2sbwlb4qnfx8o",
    "created": "2022-12-20 07:43:20.393Z",
    "updated": "2022-12-20 07:43:20.393Z",
    "name": "recipe_steps",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "ek9vpauj",
        "name": "number",
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
        "id": "4l4m0kfg",
        "name": "instruction",
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
        "id": "ddisrliw",
        "name": "note",
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
  const collection = dao.findCollectionByNameOrId("3e2sbwlb4qnfx8o");

  return dao.deleteCollection(collection);
})
