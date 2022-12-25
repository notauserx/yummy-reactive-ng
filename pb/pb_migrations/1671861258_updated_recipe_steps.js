migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("3e2sbwlb4qnfx8o")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "yrb25vfb",
    "name": "recipeId",
    "type": "relation",
    "required": false,
    "unique": false,
    "options": {
      "maxSelect": 1,
      "collectionId": "02m04h8oj0df37u",
      "cascadeDelete": false
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("3e2sbwlb4qnfx8o")

  // remove
  collection.schema.removeField("yrb25vfb")

  return dao.saveCollection(collection)
})
