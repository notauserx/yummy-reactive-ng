migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "ewr3v0wv",
    "name": "steps",
    "type": "relation",
    "required": false,
    "unique": false,
    "options": {
      "maxSelect": null,
      "collectionId": "3e2sbwlb4qnfx8o",
      "cascadeDelete": false
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // remove
  collection.schema.removeField("ewr3v0wv")

  return dao.saveCollection(collection)
})
