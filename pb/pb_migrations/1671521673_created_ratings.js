migrate((db) => {
  const collection = new Collection({
    "id": "kfdh0zfadtsv8sf",
    "created": "2022-12-20 07:34:33.819Z",
    "updated": "2022-12-20 07:34:33.819Z",
    "name": "ratings",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "tv6bpkmt",
        "name": "rating",
        "type": "number",
        "required": false,
        "unique": false,
        "options": {
          "min": 0,
          "max": 5
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
  const collection = dao.findCollectionByNameOrId("kfdh0zfadtsv8sf");

  return dao.deleteCollection(collection);
})
