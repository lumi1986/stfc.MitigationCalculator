data "azurerm_resource_group" "default" {
  name = var.resource_group_name
}

resource "azurerm_resource_group" "mitigation_calculator" {
  name     = "mitigation_calculator_${var.environment_short_name}"
  count    = var.is_vritual ? 0 : 1
  location = data.azurerm_resource_group.default.location
}

resource "azurerm_container_app" "mitigation_calculator" {
  name                         = "mitigationcalculator-${var.environment_short_name}"
  count                        = var.is_vritual ? 0 : 1
  container_app_environment_id = var.container_app_environment_id
  resource_group_name          = azurerm_resource_group.mitigation_calculator[0].id
  revision_mode                = "Single"

  template {
    container {
      name   = "mitigationcalculator"
      image  = "ghcr.io/lumi1986/stfc.mitigationcalculator:main"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }
}