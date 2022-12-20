migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // update
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "xmqzvw3n",
    "name": "serves",
    "type": "number",
    "required": false,
    "unique": false,
    "options": {
      "min": null,
      "max": null
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // update
  collection.schema.addField(new SchemaField({
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
  }))

  return dao.saveCollection(collection)
})
