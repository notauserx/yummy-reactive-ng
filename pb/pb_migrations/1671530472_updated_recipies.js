migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("02m04h8oj0df37u")

  // update
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "2qbt1bsh",
    "name": "cookingTime",
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
    "id": "2qbt1bsh",
    "name": "cookTime",
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
