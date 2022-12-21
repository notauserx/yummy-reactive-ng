migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // remove
  collection.schema.removeField("gy1tbko1")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "ap8cvfvc",
    "name": "rating",
    "type": "number",
    "required": false,
    "unique": false,
    "options": {
      "min": 1,
      "max": 5
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // add
  collection.schema.addField(new SchemaField({
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
  }))

  // remove
  collection.schema.removeField("ap8cvfvc")

  return dao.saveCollection(collection)
})
