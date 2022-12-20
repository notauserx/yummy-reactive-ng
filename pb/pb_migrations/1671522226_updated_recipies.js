migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // remove
  collection.schema.removeField("621suf8x")

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // add
  collection.schema.addField(new SchemaField({
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
  }))

  return dao.saveCollection(collection)
})
