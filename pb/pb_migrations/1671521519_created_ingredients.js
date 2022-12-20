migrate((db) => {
  const collection = new Collection({
    "id": "uododknfckaqt1l",
    "created": "2022-12-20 07:31:59.427Z",
    "updated": "2022-12-20 07:31:59.427Z",
    "name": "ingredients",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "jt1u5gvd",
        "name": "item",
        "type": "text",
        "required": false,
        "unique": false,
        "options": {
          "min": 4,
          "max": 100,
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
  const collection = dao.findCollectionByNameOrId("uododknfckaqt1l");

  return dao.deleteCollection(collection);
})
