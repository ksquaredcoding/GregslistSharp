<template>
  <div class="row justify-content-evenly m-2 p-2">
    <div class="col-md-3">
      <router-link :to="{
        name: 'Cars',
      }">
        <button class="btn btn-primary fs-1">Cars</button>
      </router-link>
    </div>
    <div class="col-md-3">
      <router-link :to="{
        name: 'Jobs',
      }">
        <button class="btn btn-secondary fs-1">Jobs</button>
      </router-link>
    </div>
    <div class="col-md-3">
      <router-link :to="{
        name: 'Houses',
      }">
        <button class="btn btn-info fs-1">Houses</button>
      </router-link>
    </div>
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>
