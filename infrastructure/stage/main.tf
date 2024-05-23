resource "azurerm_resource_group" "mitigation_calculator" {
  name = "mitigation_calculator"
  location = "Switzerland North"
}

resource "azurerm_storage_account" "function_app" {
  name                     = "mitigation_calculator_function_app_storage_account"
  resource_group_name      = azurerm_resource_group.mitigation_calculator.name
  location                 = azurerm_resource_group.mitigation_calculator.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_service_plan" "function_app" {
  name                = "mitigation_calculator_function_app_service_plan"
  resource_group_name = azurerm_resource_group.mitigation_calculator.name
  location            = azurerm_resource_group.mitigation_calculator.location
  os_type             = "Windows"
  sku_name            = "Y1"
}

resource "azurerm_windows_function_app" "function_app" {
  name                = "example-windows-function-app"
  resource_group_name = azurerm_resource_group.mitigation_calculator.name
  location            = azurerm_resource_group.mitigation_calculator.location

  storage_account_name       = azurerm_storage_account.function_app.name
  storage_account_access_key = azurerm_storage_account.function_app.primary_access_key
  service_plan_id            = azurerm_service_plan.function_app.id

  site_config {}
}